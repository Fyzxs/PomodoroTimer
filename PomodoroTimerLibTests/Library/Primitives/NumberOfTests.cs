using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLibTests.Library.Primitives
{
    [TestClass]
    public class NumberOfTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnValue()
        {
            //Arrange
            NumberOf doubleOf = new NumberOf(5.0);

            //Act
            double value = doubleOf;

            //Assert
            value.Should().Be(5.0);
        }
    }
}