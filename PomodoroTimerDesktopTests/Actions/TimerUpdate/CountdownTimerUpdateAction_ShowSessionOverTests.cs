using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_ShowSessionOverTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldShowSessionMessage()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockMainForm mockMainForm = new MockMainForm.Builder().ShowAlert().Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_ShowSessionOver subject = new CountdownTimerUpdateAction_ShowSessionOver(nextAction);

            // Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            mockMainForm.AssertShowAlertInvokedWithCustom(text => ((string)text).Should().Be("Session Over! Take a Break!\nYou know it makes the day better."));
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }
    }
}