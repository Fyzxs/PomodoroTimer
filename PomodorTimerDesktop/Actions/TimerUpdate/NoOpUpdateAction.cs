using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class NoOpUpdateAction : ICountdownTimerUpdateAction
    {
        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) { }
    }
}