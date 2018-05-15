using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate.Session;
using PomodorTimerDesktop.Timers;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class SessionPomodoroPeriod : PomodoroPeriod
    {
        public SessionPomodoroPeriod() :
            base(new SessionTimer(), new SessionTimerStartAction(), new SessionTimerUpdateAction())
        { }
    }
}