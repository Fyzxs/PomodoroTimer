using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Instant;
using System;

namespace PomodoroTimerLibTests.Library.Time.Instant
{
    [TestClass]
    public class NowAtFirstAccessTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeNowOfFirstAccess()
        {
            NowAtFirstAccess subject = new NowAtFirstAccess();
            DateTime now = DateTime.Now;

            //Act
            DateTime actual = subject;

            //Assert
            actual.Should().BeAfter(now);
        }
    }
}