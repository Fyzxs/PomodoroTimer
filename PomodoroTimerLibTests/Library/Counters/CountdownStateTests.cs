using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Counters
{
    [TestClass]
    public class CountdownStateTests
    {
        [TestMethod, TestCategory("unit")]
        public void Finished_ReturnsTrueWhenEventsLess()
        {
            //Arrange
            Number events = new NumberOf(10);
            Number counterValue = new NumberOf(11);
            MockCounter mockCounter = new MockCounter.Builder().Value(counterValue).Build();
            CountdownState subject = new CountdownState(events, mockCounter);

            //Act
            bool actual = subject.Finished();

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void Finished_ReturnsFalseWhenEventsNotLess()
        {
            //Arrange
            Number events = new NumberOf(10);
            Number counterValue = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Value(counterValue).Build();
            CountdownState subject = new CountdownState(events, mockCounter);

            //Act
            bool actual = subject.Finished();

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void Last_ReturnsTrueWhenEventsNotLess()
        {
            //Arrange
            Number events = new NumberOf(10);
            Number counterValue = new NumberOf(10);
            MockCounter mockCounter = new MockCounter.Builder().Value(counterValue).Build();
            CountdownState subject = new CountdownState(events, mockCounter);

            //Act
            bool actual = subject.Last();

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void Last_ReturnsFalseWhenEventsLess()
        {
            //Arrange
            Number events = new NumberOf(10);
            Number counterValue = new NumberOf(11);
            MockCounter mockCounter = new MockCounter.Builder().Value(counterValue).Build();
            CountdownState subject = new CountdownState(events, mockCounter);

            //Act
            bool actual = subject.Last();

            //Assert
            actual.Should().BeFalse();
        }
    }
}