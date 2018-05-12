using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class HalfSecondRepeatingTimer : DelegatingTimer
    {
        private static readonly TimeInterval RepeatIntervalMilliseconds = new Milliseconds(500);
        private static readonly TimerAutoReset TimerAutoReset = TimerAutoReset.Repeat;

        public HalfSecondRepeatingTimer() : base(new TimerBookEnd(RepeatIntervalMilliseconds, TimerAutoReset)) { }
    }
}