using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLibTests.Library.Primitives
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

        private class TestBool : Bool
        {
            protected override bool Value() => true;
        }
    }
}