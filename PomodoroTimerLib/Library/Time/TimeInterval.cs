using PomodoroTimerLib.Library.Primitives;
using System;

namespace PomodoroTimerLib.Library.Time
{
    public abstract class TimeInterval
    {
        public static implicit operator TimeSpan(TimeInterval origin) => origin.Value();
        protected abstract TimeSpan Value();
        public DoubleNumber Milliseconds() => new TimeIntervalAsMilliseconds(this);
    }
}