using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class HalfSecondRepeatingEventTimer : EventTimer
    {
        //TODO: I don't like how the 500 is arbitrary...
        private static readonly DoubleNumber RepeatIntervalMilliseconds = new DoubleNumberOf(500d);
        public HalfSecondRepeatingEventTimer() : base((DoubleNumber)RepeatIntervalMilliseconds, (TimerBookEndAutoReset)TimerBookEndAutoReset.Repeat) { }
    }
}