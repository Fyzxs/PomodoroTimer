using System;
using PomodoroTimerLib.Library.Time;

namespace PomodorTimerDesktop.Periods {
    internal sealed class TimerUpdatePeriod : TimeInterval
    {
        protected override TimeSpan Value() => TimeSpan.FromMilliseconds(500);
    }
}