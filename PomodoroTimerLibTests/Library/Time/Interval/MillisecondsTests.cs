using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class MillisecondsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTimeSpanOfProvided()
        {
            //Arrange
            Milliseconds subject = new Milliseconds(500);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.FromMilliseconds(500));
        }
    }
}