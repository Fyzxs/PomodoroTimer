﻿using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate
{
    internal sealed class CountdownTimerUpdateAction_ShowSessionStart : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_ShowSessionStart(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            mainForm.SessionStartVisibility().Show();
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}