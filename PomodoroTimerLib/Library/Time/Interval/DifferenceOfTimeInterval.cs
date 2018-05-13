using System;

namespace PomodoroTimerLib.Library.Time.Interval {
    internal sealed class DifferenceOfTimeInterval : TimeInterval
    {
        private readonly TimeInterval _minuend;
        private readonly TimeInterval _subtrahend;

        public DifferenceOfTimeInterval(TimeInterval minuend, TimeInterval subtrahend)
        {
            _minuend = minuend;
            _subtrahend = subtrahend;
        }

        protected override TimeSpan Value() => ((TimeSpan)_minuend).Subtract(_subtrahend);
    }
}