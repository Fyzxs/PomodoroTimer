using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class RepeatingEventTimer : EventTimer
    {
        public RepeatingEventTimer(TimeInterval interval) : base(interval, TimerAutoReset.Repeat) { }
    }
}