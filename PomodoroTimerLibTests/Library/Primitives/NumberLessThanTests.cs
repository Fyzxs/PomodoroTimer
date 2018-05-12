using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLibTests.Library.Primitives
{
    [TestClass]
    public class NumberLessThanTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeTrueGivenLessThan()
        {
            //Arrange
            NumberOf larger = new NumberOf(555);
            NumberOf smaller = new NumberOf(123);
            Bool subject = smaller.LessThan(larger);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeTrue();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldBeFalseGivenNotLessThan()
        {
            //Arrange
            NumberOf larger = new NumberOf(555);
            NumberOf smaller = new NumberOf(123);
            Bool subject = larger.LessThan(smaller);

            //Act
            bool actual = subject;

            //Assert
            actual.Should().BeFalse();
        }
    }
}