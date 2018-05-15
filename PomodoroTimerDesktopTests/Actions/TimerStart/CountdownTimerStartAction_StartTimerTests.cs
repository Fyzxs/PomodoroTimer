using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;

namespace PomodoroTimerDesktopTests.Actions.TimerStart
{
    [TestClass]
    public class CountdownTimerStartAction_StartTimerTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldStartTimer()
        {
            //Arrange
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Start().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            CountdownTimerStartAction_StartTimer subject = new CountdownTimerStartAction_StartTimer(nextAction);


            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            mockCountdownTimer.AssertStartInvoked();
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
}