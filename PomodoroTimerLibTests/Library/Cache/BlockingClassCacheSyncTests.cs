using FluentAssertions;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Cache;
using PomodoroTimerLib.Library.Threading;
using PomodoroTimerLibTests.Mocks;
using System;

namespace PomodoroTimerLibTests.Library.Cache
{
    [TestClass]
    public class BlockingClassCacheSyncTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldRetrieveAndLock()
        {
            // Arrange
            MockSemaphoreSlimBookEnd mockSemaphoreSlimBookEnd = new MockSemaphoreSlimBookEnd.Builder().WaitSync().Release().Build();
            MockCacheSync<string> mockCache = new MockCacheSync<string>.Builder().Retrieve("return-value").Build();
            BlockingClassCacheSync<string> subject = new BlockingClassCacheSync<string>(mockSemaphoreSlimBookEnd, mockCache);

            // Act
            string actual = subject.Retrieve(() => null);

            // Assert
            actual.Should().Be("return-value");
            mockSemaphoreSlimBookEnd.AssertWaitSyncInvoked();
            mockSemaphoreSlimBookEnd.AssertReleaseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReleaseLockOnExceptionFromRetrieve()
        {
            // Arrange
            MockSemaphoreSlimBookEnd mockSemaphoreSlimBookEnd = new MockSemaphoreSlimBookEnd.Builder().WaitSync().Release().Build();
            MockCacheSync<string> mockCache = new MockCacheSync<string>.Builder().Retrieve(() => throw new Exception()).Build();
            BlockingClassCacheSync<string> subject = new BlockingClassCacheSync<string>(mockSemaphoreSlimBookEnd, mockCache);

            // Act
            Action action = () => subject.Retrieve(() => null);

            // Assert
            action.Should().Throw<Exception>();
            mockSemaphoreSlimBookEnd.AssertWaitSyncInvoked();
            mockSemaphoreSlimBookEnd.AssertReleaseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldClearAndLock()
        {
            // Arrange
            MockSemaphoreSlimBookEnd mockSemaphoreSlimBookEnd = new MockSemaphoreSlimBookEnd.Builder().WaitSync().Release().Build();
            MockCacheSync<string> mockCache = new MockCacheSync<string>.Builder().Clear().Build();
            BlockingClassCacheSync<string> subject = new BlockingClassCacheSync<string>(mockSemaphoreSlimBookEnd, mockCache);

            // Act
            subject.Clear();

            // Assert
            mockCache.AssertClearInvoked();
            mockSemaphoreSlimBookEnd.AssertWaitSyncInvoked();
            mockSemaphoreSlimBookEnd.AssertReleaseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldReleaseLockOnExceptionFromClear()
        {
            // Arrange
            MockSemaphoreSlimBookEnd mockSemaphoreSlimBookEnd = new MockSemaphoreSlimBookEnd.Builder().WaitSync().Release().Build();
            MockCacheSync<string> mockCache = new MockCacheSync<string>.Builder().Clear(() => throw new Exception()).Build();
            BlockingClassCacheSync<string> subject = new BlockingClassCacheSync<string>(mockSemaphoreSlimBookEnd, mockCache);

            // Act
            Action action = () => subject.Clear();

            // Assert
            action.Should().Throw<Exception>();
            mockCache.AssertClearInvoked();
            mockSemaphoreSlimBookEnd.AssertWaitSyncInvoked();
            mockSemaphoreSlimBookEnd.AssertReleaseInvoked();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<SemaphoreSlimBookEnd>("_semaphore")
                .Add<ClassCacheSync<string>>("_cache");

            //Act
            BlockingClassCacheSync<string> subject = new BlockingClassCacheSync<string>();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}