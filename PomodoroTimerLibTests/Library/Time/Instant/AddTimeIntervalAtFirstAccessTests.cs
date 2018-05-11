using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Instant;
using System;

namespace PomodoroTimerLibTests.Library.Time.Instant
{
    [TestClass]
    public class AddTimeIntervalAtFirstAccessTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldNotSetNowUntilAccessed()
        {
            //Arrange
            TimeInterval seconds = new Seconds(0);
            AddTimeIntervalAtFirstAccess subject = new AddTimeIntervalAtFirstAccess(seconds);
            DateTime now = DateTime.Now;

            //Act
            DateTime actual = subject;

            //Assert
            actual.Should().BeAfter(now);
        }
    }
}