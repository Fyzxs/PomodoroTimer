using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate.LongBreak;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class LongBreakPomodoroPeriod : PomodoroPeriod
    {
        public LongBreakPomodoroPeriod() : //TODO : Make dynamic period
            base(new CountdownTimer(new Seconds(5), new Milliseconds(500)), new LongBreakTimerStartAction(), new LongBreakTimerUpdateAction())
        { }
    }
}