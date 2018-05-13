using PomodoroTimerLib.Library.Counters;
using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    internal sealed class ElapsedTimeIntervals : TimeInterval
    {
        private readonly TimeInterval _precision;
        private readonly ICounter _counter;

        public ElapsedTimeIntervals(TimeInterval precision, ICounter counter)
        {
            _precision = precision;
            _counter = counter;
        }

        protected override TimeSpan Value() => _precision.Multiply(_counter.Value());
    }
}