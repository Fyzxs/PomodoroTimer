using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_ShowLongBreakOverTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldShowLongBreakMessage()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().ShowAlert().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_ShowLongBreakOver subject = new CountdownTimerUpdateAction_ShowLongBreakOver(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            mockMainForm.AssertShowAlertInvokedWithCustom(text => ((string)text).Should().Be("Long Break Over!"));
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }
    }
}