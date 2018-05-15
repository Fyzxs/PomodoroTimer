using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Periods;

namespace PomodorTimerDesktop.Timers
{
    internal sealed class SessionTimer : CountdownTimer
    {
        public SessionTimer() : base(new Seconds(6), new TimerUpdatePeriod())
        { }
    }
}