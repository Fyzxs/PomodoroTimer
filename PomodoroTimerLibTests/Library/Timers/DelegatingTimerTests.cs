using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLibTests.Mocks;
using System.Threading;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class DelegatingTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateStart()
        {
            //Arrange
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Start().Build();
            TestDelegatingTImer subject = new TestDelegatingTImer(mockTimerBookEnd);

            //Act
            subject.Start();

            //Assert
            mockTimerBookEnd.AssertStartInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateClose()
        {
            //Arrange
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Close().Build();
            TestDelegatingTImer subject = new TestDelegatingTImer(mockTimerBookEnd);

            //Act
            subject.Close();

            //Assert
            mockTimerBookEnd.AssertCloseInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldDelegateTrigger()
        {
            //Arrange
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Close().Build();
            TestDelegatingTImer subject = new TestDelegatingTImer(mockTimerBookEnd);
            CountdownEvent latch = new CountdownEvent(1);
            subject.Elapsed += () => latch.Signal();

            //Act
            mockTimerBookEnd.TriggerElapsed();

            //Assert
            latch.Wait(2).Should().BeTrue();
        }

        private sealed class TestDelegatingTImer : DelegatingTimer
        {
            public TestDelegatingTImer(ITimerBookEnd eventTimer) : base(eventTimer) { }
        }
    }
}