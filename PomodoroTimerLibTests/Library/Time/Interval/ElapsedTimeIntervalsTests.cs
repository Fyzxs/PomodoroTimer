using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLibTests.Mocks;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class ElapsedTimeIntervalsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeElapsedTimeIntervals()
        {
            //Arrange
            TimeInterval precision = new Milliseconds(500);
            MockCounter mockCounter = new MockCounter.Builder().Value(new NumberOf(10)).Build();
            ElapsedTimeIntervals subject = new ElapsedTimeIntervals(precision, mockCounter);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.FromMilliseconds(500 * 10));
        }
    }
}