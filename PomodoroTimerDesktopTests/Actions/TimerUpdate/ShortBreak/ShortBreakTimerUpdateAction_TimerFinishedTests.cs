using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate.ShortBreak
{
    [TestClass]
    public class ShortBreakTimerUpdateAction_TimerFinishedTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            ShortBreakTimerUpdateAction_TimerFinished subject = new ShortBreakTimerUpdateAction_TimerFinished(nextAction);

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
                .Add<CountdownTimerUpdateAction_GuardAgainstMore>()
                .Add<CountdownTimerUpdateAction_FinishedForeColor>()
                .Add<CountdownTimerUpdateAction_RemainingTime>()
                .Add<CountdownTimerUpdateAction_EnableSessionStart>()
                .Add<CountdownTimerUpdateAction_ShowSessionStart>()
                .Add<CountdownTimerUpdateAction_HideShortBreakStart>()
                .Add<CountdownTimerUpdateAction_ShowShortBreakOver>()
                .Add<CountdownTimerUpdateAction_FormToTop>()
                .Add<NoOpUpdateAction>();

            //Act
            ShortBreakTimerUpdateAction_TimerFinished subject = new ShortBreakTimerUpdateAction_TimerFinished();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}