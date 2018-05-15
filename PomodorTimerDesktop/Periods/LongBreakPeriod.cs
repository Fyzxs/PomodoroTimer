using System;
using PomodoroTimerLib.Library.Time;

namespace PomodorTimerDesktop.Periods {
    internal sealed class LongBreakPeriod : TimeInterval
    {
        /*
         * What's the point of this class? (and the shortbreakperiod and sessionperiod)
         *
         * A) It encapsulates the behavior and knowledge of the LongBreak Period.
         * This way the LongBreakTimer doesn't know WHAT the time is, just the collaborator.
         *
         * B) If we want to change the mechanism of determining the period; this class changes.
         * If the scope of change is the LongBreak_PERIOD then only this file changes.
         * An example would be loading a configuration - this then knows the correct collaborators.
         *
         * While this MAY seem silly to break things down this far - It's what gives great speed and
         * power to a system.
         */
        protected override TimeSpan Value() => TimeSpan.FromMinutes(15);
    }
}