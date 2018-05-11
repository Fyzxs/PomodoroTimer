using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Instant;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class NowUntilTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeNowPlusInterval()
        {
            //Arrange
            TimeInstant timeInstant = new Now().Add(new Seconds(10));
            NowUntil subject = new NowUntil(timeInstant);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().BeCloseTo(new TimeSpan(0, 0, 0, 10), 1);
        }
    }
}