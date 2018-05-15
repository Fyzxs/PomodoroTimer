using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class MinutesTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldBeTimeSpanOfProvided()
        {
            //Arrange
            Minutes subject = new Minutes(500);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.FromMinutes(500));
        }
    }
}