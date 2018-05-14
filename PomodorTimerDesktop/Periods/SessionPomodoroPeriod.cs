using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate.Session;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class SessionPomodoroPeriod : PomodoroPeriod
    {
        public SessionPomodoroPeriod() : //TODO : Make dynamic period
            base(new CountdownTimer(new Seconds(6), new Milliseconds(500)), new SessionTimerStartAction(), new SessionTimerUpdateAction())
        { }
    }
}