using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class TimerAutoResetTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRepeatingBeTrue()
        {
            //Arrange
            //Act
            bool actual = TimerAutoReset.Repeat;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldSingleBeFalse()
        {
            //Arrange
            //Act
            bool actual = TimerAutoReset.Single;

            //Assert
            actual.Should().BeFalse();
        }
    }
}