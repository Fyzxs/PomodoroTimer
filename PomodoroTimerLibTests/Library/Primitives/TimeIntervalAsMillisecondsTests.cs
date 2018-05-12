using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLibTests.Library.Primitives
{
    [TestClass]
    public class TimeIntervalAsMillisecondsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTimeIntervalAsMilliseconds()
        {
            //Arrange
            Seconds seconds = new Seconds(100);
            TimeIntervalAsMilliseconds timeIntervalAsMilliseconds = new TimeIntervalAsMilliseconds(seconds);

            //Act
            double actual = timeIntervalAsMilliseconds;

            //Assert
            actual.Should().Be(100_000);
        }
    }
}