using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Periods;

namespace PomodoroTimerDesktopTests.Periods
{
    [TestClass]
    public class PomodoroPeriodTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeActionGivenStart()
        {
            //Arrange
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction startAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            MockCountdownTimerUpdateAction updateAction = new MockCountdownTimerUpdateAction.Builder().Build();

            PomodoroPeriod subject = new TestPomodoroPeriod(mockCountdownTimer, startAction, updateAction);

            //Act
            subject.SetMainForm(mockMainForm);
            subject.Start();

            //Assert
            startAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldInvokeUpdateOnTrigger()
        {
            //Arrange
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction startAction = new MockCountdownTimerStartAction.Builder().Build();
            MockCountdownTimerUpdateAction updateAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            PomodoroPeriod subject = new TestPomodoroPeriod(mockCountdownTimer, startAction, updateAction);

            subject.SetMainForm(mockMainForm);

            //Act
            mockCountdownTimer.TriggerElapsed(mockCountdownTime, TimerProgress.Last);

            //Assert
            updateAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, TimerProgress.Last);
        }
        private class TestPomodoroPeriod : PomodoroPeriod
        {
            public TestPomodoroPeriod(ICountdownTimer timer, ICountdownTimerStartAction startAction, ICountdownTimerUpdateAction updateAction) :
                base(timer, startAction, updateAction)
            { }
        }
    }
}