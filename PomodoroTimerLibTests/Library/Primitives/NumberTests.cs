using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLibTests.Library.Primitives
{
    [TestClass]
    public class NumberTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCastValue()
        {
            //Arrange
            Number subject = new TestNumber(1);

            //Act
            double actual = subject;

            //Assert
            actual.Should().Be(1);
        }
        private class TestNumber : Number
        {
            private readonly double _origin;

            public TestNumber(double origin) => _origin = origin;

            protected override double Value() => _origin;
        }
    }
}