using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Cache;

namespace PomodoroTimerLibTests.Library.Cache
{
    [TestClass]
    public class ClassCacheSyncTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRetrieveFromFunc()
        {
            // Arrange
            ClassCacheSync<string> subject = new ClassCacheSync<string>();

            // Act
            string actual = subject.Retrieve(() => "first-value");

            // Assert
            actual.Should().Be("first-value");
        }


        [TestMethod, TestCategory("unit")]
        public void ShouldRetrieveFromCache()
        {
            // Arrange
            ClassCacheSync<string> subject = new ClassCacheSync<string>();
            subject.Retrieve(() => "first-value");

            // Act
            string actual = subject.Retrieve(() => "second-value");

            // Assert
            actual.Should().Be("first-value");
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldRetrieveSecondAfterClear()
        {
            // Arrange
            ClassCacheSync<string> subject = new ClassCacheSync<string>();

            // Act
            subject.Retrieve(() => "first-value");
            subject.Clear();
            string second = subject.Retrieve(() => "second-value");

            // Assert
            second.Should().Be("second-value");
        }
    }
}