using FluentAssertions;
using InterfaceMocks.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLibTests.Mocks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class TimeLeftTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldStartTimersGivenStart()
        {
            //Arrange
            MockTimer mockUpdateTimer = new MockTimer.Builder().Start().Build();
            MockTimer mockActualTimer = new MockTimer.Builder().Start().Build();
            TimeInterval interval = new Milliseconds(10);
            TimeLeftTimer subject = new PrivateCtor<TimeLeftTimer>(interval, mockActualTimer, mockUpdateTimer);

            //Act
            subject.Start();

            //Assert
            mockUpdateTimer.AssertStartInvoked();
            mockActualTimer.AssertStartInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldCloseTimersGivenClose()
        {
            //Arrange
            MockTimer mockUpdateTimer = new MockTimer.Builder().Close().Build();
            MockTimer mockActualTimer = new MockTimer.Builder().Close().Build();
            TimeInterval interval = new Milliseconds(10);
            TimeLeftTimer subject = new PrivateCtor<TimeLeftTimer>(interval, mockActualTimer, mockUpdateTimer);

            //Act
            subject.Close();

            //Assert
            mockUpdateTimer.AssertCloseInvoked();
            mockActualTimer.AssertCloseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldUpdateWithTimeLeft()
        {
            //Arrange
            MockTimer mockUpdateTimer = new MockTimer.Builder().Build();
            MockTimer mockActualTimer = new MockTimer.Builder().Build();
            TimeInterval interval = new Seconds(10);
            TimeLeftTimer subject = new PrivateCtor<TimeLeftTimer>(interval, mockActualTimer, mockUpdateTimer);
            List<TimeInterval> intervals = new List<TimeInterval>();
            CountdownEvent latch = new CountdownEvent(1);
            subject.TimeLeft += end =>
            {
                latch.Signal();
                intervals.Add(end);
            };

            //Act
            mockUpdateTimer.TriggerElapsed();

            //Assert
            latch.Wait(1000).Should().BeTrue();
            ((TimeSpan)intervals[0]).Should().BeCloseTo(new TimeSpan(0, 0, 0, 10));
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldTriggerActualOnIntervalElapsedAndCloseTimers()
        {
            //Arrange
            MockTimer mockUpdateTimer = new MockTimer.Builder().Close().Build();
            MockTimer mockActualTimer = new MockTimer.Builder().Close().Build();
            TimeInterval interval = new Seconds(10);
            TimeLeftTimer subject = new PrivateCtor<TimeLeftTimer>(interval, mockActualTimer, mockUpdateTimer);
            CountdownEvent latch = new CountdownEvent(1);
            subject.Elapsed += () => latch.Signal();

            //Act
            mockActualTimer.TriggerElapsed();

            //Assert
            latch.Wait(1000).Should().BeTrue();
            mockUpdateTimer.AssertCloseInvoked();
            mockActualTimer.AssertCloseInvoked();
        }
    }
}