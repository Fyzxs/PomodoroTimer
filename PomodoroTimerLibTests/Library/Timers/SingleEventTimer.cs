using PomodoroTimerLibTests.Library.Time;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class SingleEventTimer : EventTimer
    {
        public SingleEventTimer(Milliseconds interval) : base(interval, TimerBookEndAutoReset.Single) { }
    }
}