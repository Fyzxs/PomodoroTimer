using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Instant;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class NowAtFirstAccessUntilTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldBeNowAtFirstAccessPlusInterval()
        {
            //Arrange
            TimeInstant timeInstant = new Now();
            NowAtFirstAccessUntil subject = new NowAtFirstAccessUntil(timeInstant);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().BeCloseTo(new TimeSpan(0, 0, 0, 0), 1);
            actual.Should().BeNegative();
        }
    }
}