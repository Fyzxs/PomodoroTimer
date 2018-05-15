using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;

namespace PomodoroTimerDesktopTests.Actions.TimerStart
{
    [TestClass]
    public class CountdownTimerStartAction_DisableShortBreakStartTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisableShortBreak()
        {
            //Arrange
            MockEnabled mockEnabled = new MockEnabled.Builder().Disable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().ShortBreakStartEnabled(mockEnabled).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            CountdownTimerStartAction_DisableShortBreakStart subject = new CountdownTimerStartAction_DisableShortBreakStart(nextAction);


            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            mockEnabled.Disable();
            mockMainForm.AssertShortBreakStartEnabledInvoked();
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
}