using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Instant;
using System;

namespace PomodoroTimerLibTests.Library.Time.Instant
{
    [TestClass]
    public class NowTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeNow()
        {
            //Arrange
            DateTime now = DateTime.Now;
            Now subject = new Now();

            //Act
            DateTime actual = subject;

            //Assert
            actual.Should().BeCloseTo(now, 1);
        }
    }
}