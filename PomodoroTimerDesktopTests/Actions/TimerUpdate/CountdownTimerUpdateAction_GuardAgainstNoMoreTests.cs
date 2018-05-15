using InterfaceMocks.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_GuardAgainstNoMoreTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldNotActGivenLast()
        {
            //Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Build();
            CountdownTimerUpdateAction_GuardAgainstNoMore subject = new CountdownTimerUpdateAction_GuardAgainstNoMore(nextAction);

            //Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            //Assert
            try
            {
                nextAction.Act(null, null, null);
                Assert.Fail("Exception expected");
            }
            catch (TestException ignored) { }
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldActGivenMore()
        {
            //Arrange
            TimerProgress timeProgress = TimerProgress.More;
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            CountdownTimerUpdateAction_GuardAgainstNoMore subject = new CountdownTimerUpdateAction_GuardAgainstNoMore(nextAction);

            //Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            //Assert
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }
    }
}