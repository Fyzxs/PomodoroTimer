using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class DifferenceOfTimeIntervalTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldProvideDifference()
        {
            //Arrange
            TimeInterval minuend = new Milliseconds(500);
            TimeInterval subtrahend = new Milliseconds(100);
            DifferenceOfTimeInterval subject = new DifferenceOfTimeInterval(minuend, subtrahend);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.FromMilliseconds(400));
        }
    }
}