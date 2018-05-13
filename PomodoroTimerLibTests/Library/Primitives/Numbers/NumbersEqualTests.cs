using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Numbers;

namespace PomodoroTimerLibTests.Library.Primitives.Numbers
{
    [TestClass]
    public class NumbersEqualTests
    {
        private const double Tolerance = 0.0001;
        [TestMethod, TestCategory("unit")]
        public void ShouldBeEqualGivenWithinTolerance()
        {
            //Arrange
            NumberOf valueOne = new NumberOf(0.000123);
            NumberOf valueTwo = new NumberOf(0.000169);
            NumbersEqual numbersEqual = new NumbersEqual(valueOne, valueTwo);

            //Act
            bool actual = numbersEqual;

            //Assert
            actual.Should().BeTrue();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenOutsideTolerance()
        {
            //Arrange
            NumberOf valueOne = new NumberOf(0.000199999999999);
            NumberOf valueTwo = new NumberOf(0.000300);
            NumbersEqual numbersEqual = new NumbersEqual(valueOne, valueTwo);

            //Act
            bool actual = numbersEqual;

            //Assert
            actual.Should().BeFalse();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenNotEqual()
        {
            //Arrange
            NumberOf valueOne = new NumberOf(1);
            NumberOf valueTwo = new NumberOf(0.000300);
            NumbersEqual numbersEqual = new NumbersEqual(valueOne, valueTwo);

            //Act
            bool actual = numbersEqual;

            //Assert
            actual.Should().BeFalse();
        }
    }
}