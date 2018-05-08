using System;

namespace PomodoroTimerLibTests.Library.Time.Instant
{
    internal sealed class AddMilliseconds : TimeInstant
    {
        private readonly TimeInstant _timeInstant;
        private readonly Milliseconds _milliseconds;

        public AddMilliseconds(TimeInstant timeInstant, Milliseconds milliseconds)
        {
            _timeInstant = timeInstant;
            _milliseconds = milliseconds;
        }
        protected override DateTime Value() => ((DateTime)_timeInstant).AddMilliseconds(_milliseconds);
    }
}