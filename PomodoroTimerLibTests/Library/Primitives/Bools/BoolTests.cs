using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLibTests.Library.Primitives.Bools
{
    [TestClass]
    public class BoolTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnValue()
        {
            //Arrange
            Bool subject = new TestBool();

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldStaticTrueBeTrue()
        {
            //Arrange
            //Act
            bool actual = Bool.True;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldStaticFalseBeFalse()
        {
            //Arrange
            //Act
            bool actual = Bool.False;

            //Assert
            actual.Should().BeFalse();
        }

        private class TestBool : Bool
        {
            protected override bool Value() => true;
        }
    }
}