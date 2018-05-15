using InterfaceMocks.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;

namespace PomodoroTimerDesktopTests.Actions.TimerStart
{
    [TestClass]
    public class ShortBreakTimerStartActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            //Arrange
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            ShortBreakTimerStartAction subject = new PrivateCtor<ShortBreakTimerStartAction>(nextAction);

            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
}