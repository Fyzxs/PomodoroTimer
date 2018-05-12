using System;
using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLib.Library.Time.Interval {
    internal class TimeIntervalProduct : TimeInterval
    {
        private readonly TimeInterval _multiplicand;
        private readonly Number _multiplier;

        public TimeIntervalProduct(TimeInterval multiplicand, Number multiplier)
        {
            _multiplicand = multiplicand;
            _multiplier = multiplier;
        }

        protected override TimeSpan Value() => TimeSpan.FromMilliseconds(((TimeSpan)_multiplicand).TotalMilliseconds * _multiplier);
    }
}