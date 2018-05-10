using PomodoroTimerLib.Library.Primitives;
using System;

namespace PomodoroTimerLib.Library.Time.Instant
{
    internal sealed class AddMilliseconds : TimeInstant
    {
        private readonly TimeInstant _timeInstant;
        private readonly DoubleNumber _milliseconds;

        public AddMilliseconds(TimeInstant timeInstant, DoubleNumber milliseconds)
        {
            _timeInstant = timeInstant;
            _milliseconds = milliseconds;
        }
        protected override DateTime Value() => ((DateTime)_timeInstant).AddMilliseconds(_milliseconds);
    }
}