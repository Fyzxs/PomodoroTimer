using PomodoroTimerLibTests.Library.Primitives;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class RepeatingEventTimer : EventTimer
    {
        public RepeatingEventTimer(DoubleNumber interval) : base(interval, TimerBookEndAutoReset.Repeat) { }
    }
}