using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Instant;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class DifferenceOfTimeInstantTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCalculateDifference()
        {
            //Arrange
            NowAtFirstAccess later = new NowAtFirstAccess();
            Now now = new Now();
            DifferenceOfTimeInstant subject = new DifferenceOfTimeInstant(now, later);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().BeNegative();
            actual.Should().BeCloseTo(new TimeSpan());
            actual.Should().NotBe(new TimeSpan());
        }
    }
}