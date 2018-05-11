using PomodoroTimerLib.Library.Time;
using System;

namespace PomodoroTimerLib.Library.Primitives
{
    public sealed class TimeIntervalAsMilliseconds : Number
    {
        private readonly TimeInterval _timeInterval;

        public TimeIntervalAsMilliseconds(TimeInterval timeInterval) => _timeInterval = timeInterval;
        protected override double Value() => ((TimeSpan)_timeInterval).TotalMilliseconds;
    }
}