using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodoroTimerDesktopTests.Actions.TimerUpdate {
    [TestClass]
    public class CountdownTimerUpdateAction_RemainingTimeTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldWriteFormattedText()
        {
            // Arrange
            TimerProgress timeProgress = TimerProgress.Last;
            MockWriteText mockWriteText = new MockWriteText.Builder().Write().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().CountDownTextWriter(mockWriteText).Build();
            MockCountdownTime mockCountdownTime = new MockCountdownTime.Builder().Remaining(new Seconds(1)).Build();
            MockCountdownTimerUpdateAction nextAction = new MockCountdownTimerUpdateAction.Builder().Act().Build();

            CountdownTimerUpdateAction_RemainingTime subject = new CountdownTimerUpdateAction_RemainingTime(nextAction);

            //// Act
            subject.Act(mockMainForm, mockCountdownTime, timeProgress);

            // Assert
            mockWriteText.AssertWriteInvokedWithCustom(text => ((string)text).Should().Be("00:01"));
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTime, timeProgress);
        }
    }
}