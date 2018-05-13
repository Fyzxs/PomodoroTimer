using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLibTests.Mocks;

namespace PomodoroTimerLibTests.Library.Timers.CountdownActions
{
    [TestClass]
    public class CountdownTimerElapsedActionTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldAct()
        {
            // Arrange
            MockCountdownTimerElapsedAction nextAction = new MockCountdownTimerElapsedAction.Builder().Act().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            CountdownTimerElapsedAction subject = new CountdownTimerElapsedAction(nextAction);

            // Act
            subject.Act(mockCountdownTimer);

            // Assert
            nextAction.AssertActInvokedWith(mockCountdownTimer);
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldHaveExpectedOrder()
        {
            //Arrange
            ChainValidation chainValidation = new ChainValidation()
                .Add<CountdownTimerElapsedAction_FinishedGuard>()
                .Add<CountdownTimerElapsedAction_LastGuard>()
                .Add<CountdownTimerElapsedAction_Update>()
                .Add<CountdownTimerElapsedAction.NoOp>();

            //Act
            CountdownTimerElapsedAction subject = new CountdownTimerElapsedAction();

            //Assert
            chainValidation.AssertExpectedChain(subject);
        }
    }
}