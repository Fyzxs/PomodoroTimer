using InterfaceMocks.Reflection;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.Session;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate.Session {
    [TestClass]
    public class SessionTimerUpdateAction_ShowNextStartTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldCallActOnShortBreakWhenCounterLessThanSessionsToBreak()
        {
            //Arrange
            MockCountdownTimerUpdateAction shortBreak = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            MockCountdownTimerUpdateAction longBreak = new MockCountdownTimerUpdateAction.Builder().Build();
            MockCounter mockCounter = new MockCounter.Builder().Value(new NumberOf(3)).Increment().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();

            SessionTimerUpdateAction_ShowNextStart subject = new PrivateCtor<SessionTimerUpdateAction_ShowNextStart>(shortBreak, longBreak, mockCounter);

            //Act
            subject.Act(mockMainForm, mockCountdownTime, TimerProgress.Last);

            //Assert
            shortBreak.AssertActInvokedWith(mockMainForm, mockCountdownTime, TimerProgress.Last);
            mockCounter.AssertValueInvoked();
            mockCounter.AssertIncrementInvoked();
        }
        [TestMethod, TestCategory("unit")]
        public void ShouldCallActOnLongBreakWhenCounterNotLessThanSessionsToBreak()
        {
            //Arrange
            MockCountdownTimerUpdateAction shortBreak = new MockCountdownTimerUpdateAction.Builder().Build();
            MockCountdownTimerUpdateAction longBreak = new MockCountdownTimerUpdateAction.Builder().Act().Build();
            MockCounter mockCounter = new MockCounter.Builder().Value(new NumberOf(4)).Increment().Restart().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();

            SessionTimerUpdateAction_ShowNextStart subject = new PrivateCtor<SessionTimerUpdateAction_ShowNextStart>(shortBreak, longBreak, mockCounter);

            //Act
            subject.Act(mockMainForm, mockCountdownTime, TimerProgress.Last);

            //Assert
            longBreak.AssertActInvokedWith(mockMainForm, mockCountdownTime, TimerProgress.Last);
            mockCounter.AssertValueInvoked();
            mockCounter.AssertIncrementInvoked();
            mockCounter.AssertRestartInvoked();
        }
        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<CountdownTimerUpdateAction_ShowShortBreakStart>("_shortBreakAction")
                .Add<CountdownTimerUpdateAction_ShowLongBreakStart>("_longBreakAction")
                .Add<Counter>("_counter");

            //Act
            SessionTimerUpdateAction_ShowNextStart subject = new SessionTimerUpdateAction_ShowNextStart(null);

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}