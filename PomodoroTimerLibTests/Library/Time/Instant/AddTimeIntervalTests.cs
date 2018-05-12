using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Instant;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Instant
{
    [TestClass]
    public class AddTimeIntervalTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnAddedTimeIntervalToTimeInstant()
        {
            //Arrange
            TimeInstant now = new Now();
            TimeInterval tenHours = new Seconds(60 * 60 * 10);
            AddTimeInterval subject = new AddTimeInterval(now, tenHours);

            //Act
            DateTime actual = subject;

            //Assert
            actual.Should().Be(((DateTime)now).AddHours(10));
        }
    }
}