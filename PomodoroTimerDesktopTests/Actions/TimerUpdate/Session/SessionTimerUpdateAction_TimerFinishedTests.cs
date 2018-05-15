using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.Session;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate.Session {
    [TestClass]
    public class SessionTimerUpdateAction_TimerFinishedTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            SessionTimerUpdateAction_TimerFinished subject = new SessionTimerUpdateAction_TimerFinished(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrderAfterShowShortBreak()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<CountdownTimerUpdateAction_GuardAgainstMore>()
                .Add<CountdownTimerUpdateAction_FinishedForeColor>()
                .Add<CountdownTimerUpdateAction_RemainingTime>()
                .Add<CountdownTimerUpdateAction_ShowSessionOver>()
                .Add<SessionTimerUpdateAction_ShowNextStart>()
                .Add<CountdownTimerUpdateAction_ShowShortBreakStart>("_shortBreakAction")
                .Add<CountdownTimerUpdateAction_EnableLongBreakStart>()
                .Add<CountdownTimerUpdateAction_EnableShortBreakStart>()
                .Add<CountdownTimerUpdateAction_HideSessionStart>()
                .Add<CountdownTimerUpdateAction_FormToTop>()
                .Add<NoOpUpdateAction>();

            //Act
            SessionTimerUpdateAction_TimerFinished subject = new SessionTimerUpdateAction_TimerFinished();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrderAfterShowLongBreak()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<CountdownTimerUpdateAction_GuardAgainstMore>()
                .Add<CountdownTimerUpdateAction_FinishedForeColor>()
                .Add<CountdownTimerUpdateAction_RemainingTime>()
                .Add<CountdownTimerUpdateAction_ShowSessionOver>()
                .Add<SessionTimerUpdateAction_ShowNextStart>()
                .Add<CountdownTimerUpdateAction_ShowLongBreakStart>("_longBreakAction")
                .Add<CountdownTimerUpdateAction_EnableLongBreakStart>()
                .Add<CountdownTimerUpdateAction_EnableShortBreakStart>()
                .Add<CountdownTimerUpdateAction_HideSessionStart>()
                .Add<CountdownTimerUpdateAction_FormToTop>()
                .Add<NoOpUpdateAction>();

            //Act
            SessionTimerUpdateAction_TimerFinished subject = new SessionTimerUpdateAction_TimerFinished();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}