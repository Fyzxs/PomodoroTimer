using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLibTests.Library.Primitives.Numbers
{
    [TestClass]
    public class MillisecondsInTimeIntervalTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTimeIntervalAsMilliseconds()
        {
            //Arrange
            Seconds seconds = new Seconds(100);
            MillisecondsInTimeInterval millisecondsInTimeInterval = new MillisecondsInTimeInterval(seconds);

            //Act
            double actual = millisecondsInTimeInterval;

            //Assert
            actual.Should().Be(100_000);
        }
    }
}