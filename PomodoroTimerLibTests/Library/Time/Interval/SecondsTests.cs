using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class SecondsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTimeSpanOfProvided()
        {
            //Arrange
            Seconds subject = new Seconds(500);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.FromSeconds(500));
        }
    }
}