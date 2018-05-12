using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLibTests.Library.Primitives.Bools
{
    [TestClass]
    public class NotTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenFalse()
        {
            //Arrange
            Not subject = new Not(Bool.False);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenTrue()
        {
            //Arrange
            Not subject = new Not(Bool.True);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}