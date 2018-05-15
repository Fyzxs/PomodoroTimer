using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_ShowSessionStartTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockVisibility mockVisibility = new MockVisibility.Builder().Show().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().SessionStartVisibility(mockVisibility).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_ShowSessionStart subject = new CountdownTimerUpdateAction_ShowSessionStart(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
            mockMainForm.SessionStartVisibility();
            mockVisibility.AssertShowInvoked();
        }
    }
}