using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers.Delegates
{
    public delegate void RepeatSpecifiedEvent(TimeInterval duration, TimeInterval elapsed, TimerProgress isMore);
}