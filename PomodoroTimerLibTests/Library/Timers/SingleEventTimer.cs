using PomodoroTimerLibTests.Library.Primitives;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class SingleEventTimer : EventTimer
    {
        public SingleEventTimer(DoubleNumber interval) : base(interval, TimerBookEndAutoReset.Single) { }
    }
}