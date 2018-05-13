using FluentAssertions;
using InterfaceMocks.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Counters
{
    [TestClass]
    public class CountdownTimeTests
    {
        [TestMethod, TestCategory("unit")]
        public void Remaining_ReturnRemainingTimeInterval()
        {
            //Arrange
            TimeInterval interval = new Milliseconds(321);
            TimeInterval elapsed = new Milliseconds(123);
            CountdownTime subject = new PrivateCtor<CountdownTime>(interval, elapsed);

            //Act
            TimeSpan actual = subject.Remaining();

            //Assert
            actual.Should().Be(TimeSpan.FromMilliseconds(198));
        }
    }
}