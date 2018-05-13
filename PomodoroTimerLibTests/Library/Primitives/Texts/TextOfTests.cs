using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Texts;

namespace PomodoroTimerLibTests.Library.Primitives.Texts {
    [TestClass]
    public class TextOfTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnProvidedValue()
        {
            //Arrange
            TextOf subject = new TextOf("TheValue");

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("TheValue");
        }
    }
}