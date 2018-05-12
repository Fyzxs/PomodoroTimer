using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class SingleEventTimer : DelegatingEventTimer
    {
        public SingleEventTimer(TimeInterval interval) : base(new TimerBookEnd(interval, TimerAutoReset.Single)) { }
    }
}