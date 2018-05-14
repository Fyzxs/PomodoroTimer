﻿using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class CountdownTimerUpdateAction_GuardAgainstNoMore : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_GuardAgainstNoMore(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            if (more.AsBool().Not()) return;
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}