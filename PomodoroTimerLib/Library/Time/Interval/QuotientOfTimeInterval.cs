using System;
using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLib.Library.Time.Interval {
    public class QuotientOfTimeInterval : Number
    {
        private readonly TimeInterval _dividend;
        private readonly TimeInterval _divisor;

        public QuotientOfTimeInterval(TimeInterval dividend, TimeInterval divisor)
        {
            _dividend = dividend;
            _divisor = divisor;
        }

        protected override double Value() => ((TimeSpan)_dividend).TotalMilliseconds / ((TimeSpan)_divisor).TotalMilliseconds;
    }
}