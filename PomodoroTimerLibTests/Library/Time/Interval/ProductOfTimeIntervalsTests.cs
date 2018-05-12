using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class ProductOfTimeIntervalsTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldBeZeroGivenTimeSpanZero()
        {
            //Arrange
            ProductOfTimeIntervals subject = new ProductOfTimeIntervals(new Milliseconds(0), new NumberOf(1));

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.Zero);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeZeroGivenFactorZero()
        {
            //Arrange
            ProductOfTimeIntervals subject = new ProductOfTimeIntervals(new Milliseconds(100), new NumberOf(0));

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.Zero);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldMultiplyTimeSpanByFactor()
        {
            //Arrange
            ProductOfTimeIntervals subject = new ProductOfTimeIntervals(new Milliseconds(101), new NumberOf(3));

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().Be(TimeSpan.FromMilliseconds(303));
        }
    }
}