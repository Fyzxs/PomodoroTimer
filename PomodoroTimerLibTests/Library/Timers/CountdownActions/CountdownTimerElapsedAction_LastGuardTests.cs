using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Bools;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Timers.CountdownActions {
    [TestClass]
    public class CountdownTimerElapsedAction_LastGuardTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldNextActWhenNotLast()
        {
            // Arrange
            MockCountdownTimerElapsedAction nextAction = new MockCountdownTimerElapsedAction.Builder().Act().Build();
            MockCountdownState mockCountdownState = new MockCountdownState.Builder().Last(Bool.False).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().CountdownState(mockCountdownState).Build();
            CountdownTimerElapsedAction_LastGuard subject = new CountdownTimerElapsedAction_LastGuard(nextAction);

            // Act
            subject.Act(mockCountdownTimer);

            // Assert
            nextAction.AssertActInvokedWith(mockCountdownTimer);
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldGuardWhenLast()
        {
            // Arrange
            MockCountdownTimerElapsedAction nextAction = new MockCountdownTimerElapsedAction.Builder().Build();
            MockCountdownState mockCountdownState = new MockCountdownState.Builder().Last(Bool.True).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().CountdownState(mockCountdownState).Invoke().Build();
            CountdownTimerElapsedAction_LastGuard subject = new CountdownTimerElapsedAction_LastGuard(nextAction);

            // Act
            subject.Act(mockCountdownTimer);

            // Assert
            mockCountdownTimer.AssertInvokeInvokedWith(TimerProgress.Last);
        }
    }
}