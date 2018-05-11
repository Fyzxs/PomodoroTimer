using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Timers
{
    [TestClass]
    public class EventTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldStartWhenStarted()
        {
            //Arrange
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Start().Build();
            EventTimer subject = new TestEventTimer(mockTimerBookEnd);

            //Act
            subject.Start();

            //Assert
            mockTimerBookEnd.AssertStartInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldCloseWhenStarted()
        {
            //Arrange
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Close().Build();
            EventTimer subject = new TestEventTimer(mockTimerBookEnd);

            //Act
            subject.Close();

            //Assert
            mockTimerBookEnd.AssertCloseInvoked();
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeObserverWhenEventHappens()
        {
            //Arrange
            MockTimerBookEnd mockTimerBookEnd = new MockTimerBookEnd.Builder().Build();
            EventTimer subject = new TestEventTimer(mockTimerBookEnd);
            bool calledResult = false;
            subject.Elapsed += () => calledResult = true;

            //Act
            mockTimerBookEnd.TriggerElapsed();


            //Assert
            calledResult.Should().BeTrue();
        }

        private class TestEventTimer : EventTimer
        {
            public TestEventTimer(ITimerBookEnd timerBookEnd) : base(timerBookEnd) { }
        }
    }
}