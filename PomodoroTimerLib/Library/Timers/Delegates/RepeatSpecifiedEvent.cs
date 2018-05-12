using PomodoroTimerLib.Library.Primitives.Bools;
using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers.Delegates {
    public delegate void RepeatSpecifiedEvent(TimeInterval duration, TimeInterval elapsed, Bool more);
}