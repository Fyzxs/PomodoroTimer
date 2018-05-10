using System;

namespace PomodoroTimerLib.Library.Time.Instant
{
    internal sealed class AddTimeInterval : TimeInstant
    {
        private readonly TimeInstant _timeInstant;
        private readonly TimeInterval _interval;

        public AddTimeInterval(TimeInstant timeInstant, TimeInterval interval)
        {
            _timeInstant = timeInstant;
            _interval = interval;
        }
        protected override DateTime Value() => ((DateTime)_timeInstant).Add((TimeSpan)_interval);
    }
}