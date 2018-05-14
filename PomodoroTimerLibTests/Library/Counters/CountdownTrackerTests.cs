using FluentAssertions;
using InterfaceMocks.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Counters
{
    [TestClass]
    public class CountdownTrackerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateRemaining()
        {
            //Arrange
            TimeInterval expected = new Seconds(100);
            MockCounter mockCounter = new MockCounter.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Remaining(expected).Build();
            CountdownTracker subject = new PrivateCtor<CountdownTracker>(mockCounter, new NumberOf(1), mockCountdownTime);

            //Act
            TimeInterval actual = subject.Remaining();

            //Assert
            actual.Should().Be(expected);
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateIncrement()
        {
            //Arrange
            Number events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Increment().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            CountdownTracker subject = new PrivateCtor<CountdownTracker>(mockCounter, events, mockCountdownTime);

            //Act
            subject.Increment();

            //Assert
            mockCounter.AssertIncrementInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateValue()
        {
            //Arrange
            Number expected = new NumberOf(1);
            Number events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Value(expected).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            CountdownTracker subject = new PrivateCtor<CountdownTracker>(mockCounter, events, mockCountdownTime);

            //Act
            Number actual = subject.Value();

            //Assert
            actual.Should().Be(expected);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReturnComposedCountdownState()
        {
            //Arrange
            Number expected = new NumberOf(10);
            Number events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Value(expected).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            CountdownTracker subject = new PrivateCtor<CountdownTracker>(mockCounter, events, mockCountdownTime);

            //Act
            ICountdownState countdownState = subject.CountdownState();

            //Assert
            ((bool)countdownState.Finished()).Should().BeFalse();
            ((bool)countdownState.Last()).Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateRestart()
        {
            //Arrange
            Number expected = new NumberOf(1);
            Number events = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Restart().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            CountdownTracker subject = new PrivateCtor<CountdownTracker>(mockCounter, events, mockCountdownTime);

            //Act
            subject.Restart();

            //Assert
            mockCounter.AssertRestartInvoked();
        }
    }
}