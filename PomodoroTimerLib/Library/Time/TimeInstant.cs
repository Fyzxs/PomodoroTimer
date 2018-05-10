using PomodoroTimerLib.Library.Time.Instant;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLib.Library.Time
{
    public abstract class TimeInstant
    {
        public static implicit operator DateTime(TimeInstant origin) => origin.Value();

        public TimeInstant Add(TimeInterval timeInterval) => new AddTimeInterval(this, timeInterval);
        public TimeInterval Until() => new NowUntil(this);

        protected abstract DateTime Value();
    }
}