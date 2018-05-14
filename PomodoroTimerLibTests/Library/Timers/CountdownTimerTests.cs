using FluentAssertions;
using InterfaceMocks.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLibTests.Mocks;
using System.Threading;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class CountdownTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void Close_ShouldInvokeTimerBookEnd()
        {
            //Arrange
            NumberOf events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Close().Build();
            CountdownTimer subject = new PrivateCtor<CountdownTimer>(events, mockCounter, mockCountdownTime, mockTimerBookEnd);

            //Act
            subject.Stop();

            //Assert
            mockTimerBookEnd.AssertCloseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void Start_ShouldInvokeTimerBookEnd()
        {
            //Arrange
            NumberOf events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Start().Build();
            CountdownTimer subject = new PrivateCtor<CountdownTimer>(events, mockCounter, mockCountdownTime, mockTimerBookEnd);

            //Act
            subject.Start();

            //Assert
            mockTimerBookEnd.AssertStartInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void CountdownState_ShouldReturnAccurateState()
        {
            //Arrange
            NumberOf events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Value(events).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Build();
            CountdownTimer subject = new PrivateCtor<CountdownTimer>(events, mockCounter, mockCountdownTime, mockTimerBookEnd);

            //Act
            ICountdownState actual = subject.CountdownState();

            //Assert
            bool finished = actual.Finished();
            bool last = actual.Last();
            finished.Should().BeFalse();
            last.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void Invoke_ShouldTriggerEvent()
        {
            //Arrange
            NumberOf events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Increment().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Start().Build();
            CountdownTimer subject = new PrivateCtor<CountdownTimer>(events, mockCounter, mockCountdownTime, mockTimerBookEnd);
            CountdownEvent latch = new CountdownEvent(1);
            subject.RepeatSpecified += (time, more) => latch.Signal();

            //Act
            subject.Invoke(TimerProgress.More);

            //Assert
            latch.Wait(10).Should().BeTrue();
            mockCounter.AssertIncrementInvoked();
        }

        [TestMethod, TestCategory("integration")]
        public void TimerShouldBeRestartable()
        {
            CountdownTimer subject = new CountdownTimer(new Milliseconds(500), new Milliseconds(100));
            CountdownEvent latch = new CountdownEvent(5);

            subject.RepeatSpecified += (time, more) => latch.Signal();

            subject.Start();

            latch.Wait(700).Should().BeTrue();

            latch = new CountdownEvent(5);

            subject.Start();
            latch.Wait(700).Should().BeTrue();
        }



        //TODO: Test chain invoked

    }
}