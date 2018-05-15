using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;

namespace PomodoroTimerDesktopTests.Actions.TimerStart
{
    [TestClass]
    public class CountdownTimerStartAction_DisableSessionStartTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisableSession()
        {
            //Arrange
            MockEnabled mockEnabled = new MockEnabled.Builder().Disable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().SessionStartEnabled(mockEnabled).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            CountdownTimerStartAction_DisableSessionStart subject = new CountdownTimerStartAction_DisableSessionStart(nextAction);


            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            mockEnabled.Disable();
            mockMainForm.AssertSessionStartEnabledInvoked();
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
}