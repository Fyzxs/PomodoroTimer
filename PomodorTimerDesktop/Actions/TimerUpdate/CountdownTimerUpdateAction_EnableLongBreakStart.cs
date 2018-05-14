using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class CountdownTimerUpdateAction_EnableLongBreakStart : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_EnableLongBreakStart(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            mainForm.LongBreakStartEnabled().Enable();
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}