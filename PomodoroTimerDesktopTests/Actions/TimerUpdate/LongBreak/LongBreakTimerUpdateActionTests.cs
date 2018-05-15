using InterfaceMocks.Reflection;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.LongBreak;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate.LongBreak
{
    [TestClass]
    public class LongBreakTimerUpdateActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCallActOnEachAction()
        {
            //Arrange
            MockCountdownTimerUpdateAction finished = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            MockCountdownTimerUpdateAction running = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();

            LongBreakTimerUpdateAction subject = new PrivateCtor<LongBreakTimerUpdateAction>(finished, running);

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
                .Add<LongBreakTimerUpdateAction_TimerFinished>("_finished")
                .Add<CountdownTimerUpdateAction_TimerRunning>("_running");

            //Act
            LongBreakTimerUpdateAction subject = new LongBreakTimerUpdateAction();

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}