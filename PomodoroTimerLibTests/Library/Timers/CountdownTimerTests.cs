using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLib.Library.Timers.CountdownActions;
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
            MockCountdownTimerElapsedAction mockCountdownTimerElapsedAction = new MockCountdownTimerElapsedAction.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Close().Build();
            MockCountdownTracker mockCountdownTracker = new MockCountdownTracker.Builder().Build();
            CountdownTimer subject = new TestCountdownTimer(mockCountdownTimerElapsedAction, mockTimerBookEnd, mockCountdownTracker);

            //Act
            subject.Stop();

            //Assert
            mockTimerBookEnd.AssertCloseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void Start_ShouldInvokeTimerBookEnd()
        {
            //Arrange
            //Arrange
            MockCountdownTimerElapsedAction mockCountdownTimerElapsedAction = new MockCountdownTimerElapsedAction.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Start().Build();
            MockCountdownTracker mockCountdownTracker = new MockCountdownTracker.Builder().Restart().Build();
            CountdownTimer subject = new TestCountdownTimer(mockCountdownTimerElapsedAction, mockTimerBookEnd, mockCountdownTracker);

            //Act
            subject.Start();

            //Assert
            mockCountdownTracker.AssertRestartInvoked();
            mockTimerBookEnd.AssertStartInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void CountdownState_ShouldReturnAccurateState()
        {
            //Arrange
            //Arrange
            MockCountdownState mockCountdownState = new MockCountdownState.Builder().Build();
            MockCountdownTimerElapsedAction mockCountdownTimerElapsedAction = new MockCountdownTimerElapsedAction.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Build();
            MockCountdownTracker mockCountdownTracker = new MockCountdownTracker.Builder().CountdownState(mockCountdownState).Build();
            CountdownTimer subject = new TestCountdownTimer(mockCountdownTimerElapsedAction, mockTimerBookEnd, mockCountdownTracker);

            //Act
            ICountdownState actual = subject.CountdownState();

            //Assert
            actual.Should().Be(mockCountdownState);
        }

        [TestMethod, TestCategory("unit")]
        public void Invoke_ShouldTriggerEvent()
        {
            //Arrange
            //Arrange
            MockCountdownTimerElapsedAction mockCountdownTimerElapsedAction = new MockCountdownTimerElapsedAction.Builder().Build();
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Build();
            MockCountdownTracker mockCountdownTracker = new MockCountdownTracker.Builder().Increment().Build();
            CountdownTimer subject = new TestCountdownTimer(mockCountdownTimerElapsedAction, mockTimerBookEnd, mockCountdownTracker);
            CountdownEvent latch = new CountdownEvent(1);
            subject.TimerEvent += (time, more) => latch.Signal();

            //Act
            subject.Invoke(TimerProgress.More);

            //Assert
            latch.Wait(10).Should().BeTrue();
            mockCountdownTracker.AssertIncrementInvoked();
        }

        [TestMethod, TestCategory("integration")]
        public void TimerShouldBeRestartable()
        {
            CountdownTimer subject = new TestCountdownTimer(new Milliseconds(500), new Milliseconds(100));
            CountdownEvent latch = new CountdownEvent(5);

            subject.TimerEvent += (time, more) => latch.Signal();

            subject.Start();

            latch.Wait(700).Should().BeTrue();

            latch = new CountdownEvent(5);

            subject.Start();
            latch.Wait(700).Should().BeTrue();
        }

        private sealed class TestCountdownTimer : CountdownTimer
        {
            public TestCountdownTimer(TimeInterval interval, TimeInterval precision) : base(interval, precision) { }
            public TestCountdownTimer(ICountdownTimerElapsedAction countdownTimerElapsedAction, ITimerBookEnd timerBookEnd, ICountdownTracker countdownTracker) : base(countdownTimerElapsedAction, timerBookEnd, countdownTracker) { }
        }
    }
}