using InterfaceMocks.Reflection;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate.ShortBreak {
    [TestClass]
    public class ShortBreakTimerUpdateActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCallActOnEachAction()
        {
            //Arrange
            MockCountdownTimerUpdateAction finished = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            MockCountdownTimerUpdateAction running = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();

            ShortBreakTimerUpdateAction subject = new PrivateCtor<ShortBreakTimerUpdateAction>(finished, running);

            //Act
            subject.Act(mockMainForm, mockCountdownTime, TimerProgress.Last);

            //Assert
            finished.AssertActInvokedWith(mockMainForm, mockCountdownTime, TimerProgress.Last);
            running.AssertActInvokedWith(mockMainForm, mockCountdownTime, TimerProgress.Last);
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<ShortBreakTimerUpdateAction_TimerFinished>("_finished")
                .Add<CountdownTimerUpdateAction_TimerRunning>("_running");

            //Act
            ShortBreakTimerUpdateAction subject = new ShortBreakTimerUpdateAction();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}