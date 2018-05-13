using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Timers.CountdownActions {
    [TestClass]
    public class CountdownTimerElapsedAction_UpdateTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldNextActAndInvoke()
        {
            // Arrange
            MockCountdownTimerElapsedAction nextAction = new MockCountdownTimerElapsedAction.Builder().Act().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Invoke().Build();
            CountdownTimerElapsedAction_Update subject = new CountdownTimerElapsedAction_Update(nextAction);

            // Act
            subject.Act(mockCountdownTimer);

            // Assert
            nextAction.AssertActInvokedWith(mockCountdownTimer);
            mockCountdownTimer.AssertInvokeInvokedWith(TimerProgress.More);
        }
    }
}