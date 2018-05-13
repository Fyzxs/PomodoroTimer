using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLib.Library.Time
{
    public abstract class TimeInterval
    {
        public static implicit operator TimeSpan(TimeInterval origin) => origin.Value();

        protected abstract TimeSpan Value();

        public Number Milliseconds() => new TimeIntervalAsMilliseconds(this);

        public TimeInterval Multiply(Number factor) => new ProductOfTimeIntervals(this, factor);
        public TimeInterval Subtract(TimeInterval subtrahend) => new DifferenceOfTimeInterval(this, subtrahend);
        public Text Format(Text format) => new TimeIntervalToText(this, format);
    }
}