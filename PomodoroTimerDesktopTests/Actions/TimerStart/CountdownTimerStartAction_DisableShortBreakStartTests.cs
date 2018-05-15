﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerDesktopTests.Mocks;
using PomodoroTimerLibTests.Mocks;
using PomodorTimerDesktop.Actions.TimerStart;

namespace PomodoroTimerDesktopTests.Actions.TimerStart
{
    [TestClass]
    public class CountdownTimerStartAction_DisableShortBreakStartTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisableShortBreak()
        {
            //Arrange
            MockEnabled mockEnabled = new MockEnabled.Builder().Disable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().ShortBreakStartEnabled(mockEnabled).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            CountdownTimerStartAction_DisableShortBreakStart subject = new CountdownTimerStartAction_DisableShortBreakStart(nextAction);


            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            mockEnabled.Disable();
            mockMainForm.AssertShortBreakStartEnabledInvoked();
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
    [TestClass]
    public class CountdownTimerStartAction_DisableLongBreakStartTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisableLongBreak()
        {
            //Arrange
            MockEnabled mockEnabled = new MockEnabled.Builder().Disable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().LongBreakStartEnabled(mockEnabled).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            CountdownTimerStartAction_DisableLongBreakStart subject = new CountdownTimerStartAction_DisableLongBreakStart(nextAction);


            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            mockEnabled.Disable();
            mockMainForm.AssertLongBreakStartEnabledInvoked();
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }

    [TestClass]
    public class CountdownTimerStartAction_DisableSessionStartTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldDisableSession()
        {
            //Arrange
            MockEnabled mockEnabled = new MockEnabled.Builder().Disable().Build();
            MockMainForm mockMainForm = new MockMainForm.Builder().SessionStartEnable(mockEnabled).Build();
            MockCountdownTimer mockCountdownTimer = new MockCountdownTimer.Builder().Build();
            MockCountdownTimerStartAction nextAction = new MockCountdownTimerStartAction.Builder().Act().Build();
            CountdownTimerStartAction_DisableSessionStart subject = new CountdownTimerStartAction_DisableSessionStart(nextAction);


            //Act
            subject.Act(mockMainForm, mockCountdownTimer);

            //Assert
            mockEnabled.Disable();
            mockMainForm.AssertSessionStartEnableInvoked();
            nextAction.AssertActInvokedWith(mockMainForm, mockCountdownTimer);
        }
    }
}