using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class SingleTimer : DelegatingTimer
    {
        public SingleTimer(TimeInterval interval) : base(new TimerBookEnd(interval, TimerAutoReset.Single)) { }
    }
}