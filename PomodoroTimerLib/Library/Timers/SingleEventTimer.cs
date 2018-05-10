using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class SingleEventTimer : EventTimer
    {
        public SingleEventTimer(DoubleNumber interval) : base(interval, (TimerBookEndAutoReset)TimerBookEndAutoReset.Single) { }
    }
}