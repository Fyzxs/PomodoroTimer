using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class ShortBreakPomodoroPeriod : PomodoroPeriod
    {
        public ShortBreakPomodoroPeriod() : //TODO : Make dynamic period
            base(new CountdownTimer(new Seconds(3), new Milliseconds(500)), new ShortBreakTimerStartAction(), new ShortBreakTimerUpdateAction())
        { }
    }
}