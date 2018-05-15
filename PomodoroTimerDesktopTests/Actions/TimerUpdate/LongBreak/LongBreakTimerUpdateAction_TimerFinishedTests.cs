using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.LongBreak;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate.LongBreak
{
    [TestClass]
    public class LongBreakTimerUpdateAction_TimerFinishedTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            LongBreakTimerUpdateAction_TimerFinished subject = new LongBreakTimerUpdateAction_TimerFinished(nextAction);

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
                .Add<CountdownTimerUpdateAction_ShowLongBreakOver>()
                .Add<CountdownTimerUpdateAction_EnableSessionStart>()
                .Add<CountdownTimerUpdateAction_HideLongBreakStart>()
                .Add<CountdownTimerUpdateAction_ShowSessionStart>()
                .Add<CountdownTimerUpdateAction_FormToTop>()
                .Add<NoOpUpdateAction>();

            //Act
            LongBreakTimerUpdateAction_TimerFinished subject = new LongBreakTimerUpdateAction_TimerFinished();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}