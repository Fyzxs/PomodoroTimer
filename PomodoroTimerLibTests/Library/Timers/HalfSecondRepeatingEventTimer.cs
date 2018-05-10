using PomodoroTimerLibTests.Library.Primitives;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class HalfSecondRepeatingEventTimer : EventTimer
    {
        //TODO: I don't like how the 500 is arbitrary...
        private static readonly DoubleNumber RepeatIntervalMilliseconds = new DoubleNumberOf(500d);
        public HalfSecondRepeatingEventTimer() : base(RepeatIntervalMilliseconds, TimerBookEndAutoReset.Repeat) { }
    }
}