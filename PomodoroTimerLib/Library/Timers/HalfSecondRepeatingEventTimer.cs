using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class HalfSecondRepeatingEventTimer : EventTimer
    {
        private static readonly TimeInterval RepeatIntervalMilliseconds = new Milliseconds(500);
        public HalfSecondRepeatingEventTimer() : base(RepeatIntervalMilliseconds, (TimerBookEndAutoReset)TimerBookEndAutoReset.Repeat) { }
    }
}