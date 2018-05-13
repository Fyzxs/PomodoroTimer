using System;
using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Primitives.Numbers
{
    public sealed class MillisecondsInTimeInterval : Number
    {
        private readonly TimeInterval _timeInterval;

        public MillisecondsInTimeInterval(TimeInterval timeInterval) => _timeInterval = timeInterval;
        protected override double Value() => ((TimeSpan)_timeInterval).TotalMilliseconds;
    }
}