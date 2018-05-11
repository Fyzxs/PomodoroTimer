using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class HalfSecondRepeatingEventTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRepeatEvery500Ms()
        {
            //Arrange
            HalfSecondRepeatingEventTimer subject = new HalfSecondRepeatingEventTimer();
            List<TimeSpan> times = new List<TimeSpan>();
            DateTime now = DateTime.Now;
            subject.Elapsed += () =>
            {
                times.Add(DateTime.Now.Subtract(now));
            };

            //Act
            subject.Start();
            while (times.Count < 3) { Thread.Sleep(10); }
            subject.Close();

            //Assert
            times.Count.Should().Be(3);
            times[0].Should().BeCloseTo(TimeSpan.FromMilliseconds(500));
            times[1].Should().BeCloseTo(TimeSpan.FromMilliseconds(1000));
            times[2].Should().BeCloseTo(TimeSpan.FromMilliseconds(1500));
        }

    }
}