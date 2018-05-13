using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class TimerProgressTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldMoreBeTrue()
        {
            //Arrange
            //Act
            bool actual = TimerProgress.More;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldLastBeFalse()
        {
            //Arrange
            //Act
            bool actual = TimerProgress.Last;

            //Assert
            actual.Should().BeFalse();
        }
    }
}