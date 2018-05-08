using PomodoroTimerLibTests.Library.Time;
using PomodoroTimerLibTests.Library.Time.Interval;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class HalfSecondRepeatingEventTimer : EventTimer
    {
        private static readonly Milliseconds OneSecond = new FromSeconds(.5);
        public HalfSecondRepeatingEventTimer() : base(OneSecond, TimerBookEndAutoReset.Repeat) { }
    }
}