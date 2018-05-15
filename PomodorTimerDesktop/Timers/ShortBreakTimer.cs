using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Periods;

namespace PomodorTimerDesktop.Timers
{
    internal sealed class ShortBreakTimer : CountdownTimer
    {
        public ShortBreakTimer() : base(new ShortBreakPeriod(), new TimerUpdatePeriod())
        { }
    }
}