using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class RepeatingEventTimer : EventTimer
    {
        public RepeatingEventTimer(DoubleNumber interval) : base(interval, (TimerBookEndAutoReset)TimerBookEndAutoReset.Repeat) { }
    }
}