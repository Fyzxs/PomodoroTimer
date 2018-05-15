using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_ShowLongBreakStartTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockVisibility mockVisibility = new MockVisibility.Builder().Show().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().LongBreakStartVisibility(mockVisibility).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_ShowLongBreakStart subject = new CountdownTimerUpdateAction_ShowLongBreakStart(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
            mockMainForm.LongBreakStartVisibility();
            mockVisibility.AssertShowInvoked();
        }
    }
}