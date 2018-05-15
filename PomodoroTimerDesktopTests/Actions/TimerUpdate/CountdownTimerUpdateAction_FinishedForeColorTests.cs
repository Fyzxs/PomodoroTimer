using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_FinishedForeColorTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldColorForeColor()
        {
            //Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockWriteColor mockWriteColor = new MockWriteColor.Builder().Write().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().CountDownForeColorWriter(mockWriteColor).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            CountdownTimerUpdateAction_FinishedForeColor subject = new CountdownTimerUpdateAction_FinishedForeColor(nextAction);

            //Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            //Assert
            //mockWriteColor.AssertWriteInvokedWithCustom();//TODO: Make sure black is written
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }
    }
}