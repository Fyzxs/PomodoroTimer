using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal interface ICountdownTimerUpdateAction
    {
        void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more);
    }
}