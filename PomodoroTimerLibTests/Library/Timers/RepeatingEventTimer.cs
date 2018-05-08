using PomodoroTimerLibTests.Library.Time;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class RepeatingEventTimer : EventTimer
    {
        public RepeatingEventTimer(Milliseconds interval) : base(interval, TimerBookEndAutoReset.Repeat) { }
    }
}