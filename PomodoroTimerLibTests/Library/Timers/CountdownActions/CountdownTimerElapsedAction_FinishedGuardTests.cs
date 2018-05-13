using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Bools;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Timers.CountdownActions {
    [TestClass]
    public class CountdownTimerElapsedAction_FinishedGuardTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldNextActWhenNotFinished()
        {
            // Arrange
            MockCountdownTimerElapsedAction nextAction = new MockCountdownTimerElapsedAction.Builder().Act().Build();
            MockCountdownState mockCountdownState = new MockCountdownState.Builder().Finished(Bool.False).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().CountdownState(mockCountdownState).Build();
            CountdownTimerElapsedAction_FinishedGuard subject = new CountdownTimerElapsedAction_FinishedGuard(nextAction);

            // Act
            subject.Act(mockCountdownTimer);

            // Assert
            nextAction.AssertActInvokedWith(mockCountdownTimer);
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldGuardWhenFinished()
        {
            // Arrange
            MockCountdownTimerElapsedAction nextAction = new MockCountdownTimerElapsedAction.Builder().Build();
            MockCountdownState mockCountdownState = new MockCountdownState.Builder().Finished(Bool.True).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().CountdownState(mockCountdownState).Close().Build();
            CountdownTimerElapsedAction_FinishedGuard subject = new CountdownTimerElapsedAction_FinishedGuard(nextAction);

            // Act
            subject.Act(mockCountdownTimer);

            // Assert
            mockCountdownTimer.AssertCloseInvoked();

        }
    }
}