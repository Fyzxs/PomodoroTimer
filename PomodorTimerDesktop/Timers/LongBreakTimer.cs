using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Periods;

namespace PomodorTimerDesktop.Timers
{
    internal sealed class LongBreakTimer : CountdownTimer
    {
        public LongBreakTimer() : base(new LongBreakPeriod(), new TimerUpdatePeriod())
        { }
    }
}