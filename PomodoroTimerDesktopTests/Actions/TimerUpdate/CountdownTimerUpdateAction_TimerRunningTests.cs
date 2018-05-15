using InterfaceMocks.Reflection;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_TimerRunningTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_TimerRunning subject = new PrivateCtor<CountdownTimerUpdateAction_TimerRunning>(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<CountdownTimerUpdateAction_GuardAgainstNoMore>()
                .Add<CountdownTimerUpdateAction_DefaultForeColor>()
                .Add<CountdownTimerUpdateAction_RemainingTime>()
                .Add<NoOpUpdateAction>();

            //Act
            CountdownTimerUpdateAction_TimerRunning subject = new CountdownTimerUpdateAction_TimerRunning();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }

    }
}