using PomodoroTimerLibTests.Library.Time;
using System;

namespace PomodoroTimerLibTests.Library.Primitives
{

    public sealed class TimeIntervalAsMilliseconds : DoubleNumber
    {
        private readonly TimeInterval _timeInterval;

        public TimeIntervalAsMilliseconds(TimeInterval timeInterval) => _timeInterval = timeInterval;
        protected override double Value() => ((TimeSpan)_timeInterval).Milliseconds;
    }
}