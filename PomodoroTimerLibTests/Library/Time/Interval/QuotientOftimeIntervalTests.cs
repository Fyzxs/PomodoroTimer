using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class QuotientOfTimeIntervalTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnPositiveInfinityWhenDividingByZero()
        {
            //Arrange
            QuotientOfTimeInterval subject = new QuotientOfTimeInterval(new Milliseconds(500), new Milliseconds(0));
            Number almostActual = subject;

            //Act
            double actual = almostActual;

            //Assert
            actual.Should().Be(double.PositiveInfinity);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeWholeNumberOfDivisions()
        {
            //Arrange
            QuotientOfTimeInterval subject = new QuotientOfTimeInterval(new Milliseconds(500), new Milliseconds(2));
            Number almostActual = subject;

            //Act
            double actual = almostActual;

            //Assert
            actual.Should().Be(250);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeFractionalNumberOfDivisions()
        {
            //Arrange
            QuotientOfTimeInterval subject = new QuotientOfTimeInterval(new Milliseconds(500), new Milliseconds(200));
            Number almostActual = subject;

            //Act
            double actual = almostActual;

            //Assert
            actual.Should().Be(2.5);
        }
    }
}