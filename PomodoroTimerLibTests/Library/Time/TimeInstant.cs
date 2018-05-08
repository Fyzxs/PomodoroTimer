using PomodoroTimerLibTests.Library.Time.Instant;
using PomodoroTimerLibTests.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time
{
    public abstract class TimeInstant
    {

        public static implicit operator DateTime(TimeInstant origin) => origin.Value();

        public TimeInstant AddMilliseconds(Milliseconds milliseconds) => new AddMilliseconds(this, milliseconds);
        public TimeInterval Until() => new NowUntil(this);

        protected abstract DateTime Value();
    }
}