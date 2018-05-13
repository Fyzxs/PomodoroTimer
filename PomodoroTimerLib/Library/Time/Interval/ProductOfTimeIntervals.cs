using PomodoroTimerLib.Library.Primitives.Numbers;
using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    internal class ProductOfTimeIntervals : TimeInterval
    {
        private readonly TimeInterval _multiplicand;
        private readonly Number _multiplier;

        public ProductOfTimeIntervals(TimeInterval multiplicand, Number multiplier)
        {
            _multiplicand = multiplicand;
            _multiplier = multiplier;
        }

        protected override TimeSpan Value() => TimeSpan.FromMilliseconds(((TimeSpan)_multiplicand).TotalMilliseconds * _multiplier);
    }
}