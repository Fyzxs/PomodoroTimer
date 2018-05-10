using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class SingleEventTimer : EventTimer
    {
        public SingleEventTimer(TimeInterval interval) : base(interval, TimerBookEndAutoReset.Single) { }
    }
}