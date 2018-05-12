using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLibTests.Library.Primitives.Bools
{
    [TestClass]
    public class BoolOfTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenFalse()
        {
            //Arrange
            BoolOf subject = new BoolOf(false);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenTrue()
        {
            //Arrange
            BoolOf subject = new BoolOf(true);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
    }
}