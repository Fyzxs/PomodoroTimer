using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class RepeatingEventTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRepeatEveryInterval()
        {
            //Arrange
            RepeatingTimer subject = new RepeatingTimer(new Milliseconds(10));
            List<TimeSpan> times = new List<TimeSpan>();
            DateTime now = DateTime.Now;

            CountdownEvent latch = new CountdownEvent(3);
            subject.Elapsed += () =>
            {
                latch.Signal();
                times.Add(DateTime.Now.Subtract(now));
            };

            //Act
            subject.Start();

            latch.Wait(50).Should().BeTrue();
            subject.Close();

            //Assert
            times.Count.Should().Be(3);
            times[0].Should().BeCloseTo(TimeSpan.FromMilliseconds(10));
            times[1].Should().BeCloseTo(TimeSpan.FromMilliseconds(20));
            times[2].Should().BeCloseTo(TimeSpan.FromMilliseconds(30));
        }
    }
}