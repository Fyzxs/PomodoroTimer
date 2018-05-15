using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_EnableShortBreakStartTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockEnabled mockEnabled = new MockEnabled.Builder().Enable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().ShortBreakStartEnabled(mockEnabled).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_EnableShortBreakStart subject = new CountdownTimerUpdateAction_EnableShortBreakStart(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
            mockMainForm.AssertShortBreakStartEnabledInvoked();
            mockEnabled.AssertEnableInvoked();
        }
    }
}