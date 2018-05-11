using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers;
using System;
using System.Threading;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class SingleEventTimerTests
    {
        /*
         * Note: Might be a little flakey. Threading and timing, especially at the ms level
         */
        [TestMethod, TestCategory("unit")]
        public void ShouldTriggerOnceAfterInterval()
        {
            //Arrange
            SingleEventTimer subject = new SingleEventTimer(new Milliseconds(4));
            CountdownEvent latch = new CountdownEvent(1);
            subject.Elapsed += () =>
            {
                latch.Signal();
            };

            //Act
            subject.Start();
            DateTime startTime = DateTime.Now;

            //Assert
            latch.Wait(20).Should().BeTrue();
            TimeSpan timeSpan = DateTime.Now.Subtract(startTime);
            timeSpan.Should().BeCloseTo(new TimeSpan(0, 0, 0, 0, 6), because: "Actual TimeSpan: " + timeSpan.TotalMilliseconds);
        }
    }
}