using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate.LongBreak;
using PomodorTimerDesktop.Timers;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class LongBreakPomodoroPeriod : PomodoroPeriod
    {
        public LongBreakPomodoroPeriod() :
            base(new LongBreakTimer(), new LongBreakTimerStartAction(), new LongBreakTimerUpdateAction())
        { }
    }
}