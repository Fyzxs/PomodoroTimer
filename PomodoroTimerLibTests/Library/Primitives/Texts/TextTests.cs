using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Texts;

namespace PomodoroTimerLibTests.Library.Primitives.Texts
{
    [TestClass]
    public class TextTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnProvidedValue()
        {
            //Arrange
            TestText subject = new TestText("TheValue");

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("TheValue");
        }


        private sealed class TestText : Text
        {
            private readonly string _origin;

            public TestText(string origin) => _origin = origin;
            protected override string Value() => _origin;
        }
    }
}