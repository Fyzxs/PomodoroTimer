using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    //TODO: This dies with TimeLeftSingleEventTimer
    public delegate void TimerLeftEvent(TimeInterval timeSpanBookEnd, Bool repeating);
}