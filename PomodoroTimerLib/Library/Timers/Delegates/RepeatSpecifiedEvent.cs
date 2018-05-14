using PomodoroTimerLib.Library.Counters;

namespace PomodoroTimerLib.Library.Timers.Delegates
{
    public delegate void CountdownTimerEvent(ICountdownTime countdownTime, TimerProgress isMore);
}