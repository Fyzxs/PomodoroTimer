using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class HalfSecondRepeatingEventTimer : EventTimer
    {
        private static readonly TimeInterval RepeatIntervalMilliseconds = new Milliseconds(500);
        private static readonly TimerAutoReset TimerAutoReset = TimerAutoReset.Repeat;

        public HalfSecondRepeatingEventTimer() : base(RepeatIntervalMilliseconds, TimerAutoReset) { }
    }
}