using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_EnableSessionStartTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockEnabled mockEnabled = new MockEnabled.Builder().Enable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().SessionStartEnabled(mockEnabled).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_EnableSessionStart subject = new CountdownTimerUpdateAction_EnableSessionStart(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
            mockMainForm.AssertSessionStartEnabledInvoked();
            mockEnabled.AssertEnableInvoked();
        }
    }
}