using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak;
using PomodorTimerDesktop.Timers;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class ShortBreakPomodoroPeriod : PomodoroPeriod
    {
        public ShortBreakPomodoroPeriod() :
            base(new ShortBreakTimer(), new ShortBreakTimerStartAction(), new ShortBreakTimerUpdateAction())
        { }
    }
}