using System;
using PomodoroTimerLib.Library.Time;

namespace PomodorTimerDesktop.Periods {
    internal sealed class ShortBreakPeriod : TimeInterval
    {
        /*
         * What's the point of this class? See LongBreakPeriod
         */
        protected override TimeSpan Value() => TimeSpan.FromMinutes(7);
    }
}