using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    internal sealed class DifferenceOfTimeInstant : TimeInterval
    {
        private readonly TimeInstant _minuend;
        private readonly TimeInstant _subtrahend;

        public DifferenceOfTimeInstant(TimeInstant minuend, TimeInstant subtrahend)
        {
            _minuend = minuend;
            _subtrahend = subtrahend;
        }

        protected override TimeSpan Value() => ((DateTime)_minuend).Subtract(_subtrahend);
    }
}