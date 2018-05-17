using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Periods;

namespace PomodorTimerDesktop.Timers
{
    internal sealed class SessionTimer : CountdownTimer
    {
        public SessionTimer() : base(new SessionPeriod(), new TimerUpdatePeriod())
        { }
    }
}