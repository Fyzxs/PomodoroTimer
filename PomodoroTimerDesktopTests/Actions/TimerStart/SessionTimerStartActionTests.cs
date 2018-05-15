using InterfaceMocks.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;

namespace PomodoroTimerDesktopTests.Actions.TimerStart
{
    [TestClass]
    public class SessionTimerStartActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            //Arrange
            //Arrange
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            SessionTimerStartAction subject = new PrivateCtor<SessionTimerStartAction>(nextAction);

            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
}