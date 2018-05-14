﻿using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class CountdownTimerStartAction_DisableSessionStart : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public CountdownTimerStartAction_DisableSessionStart(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, CountdownTimer timer)
        {
            form.SessionStartEnable().Disable();
            _nextAction.Act(form, timer);
        }
    }
}