using System;

namespace PomodoroTimerLib.Library.Time.Interval {
    public sealed class Minutes : TimeInterval
    {
        private readonly double _minutes;
        public Minutes(double minutes) => _minutes = minutes;
        protected override TimeSpan Value() => TimeSpan.FromMinutes(_minutes);
    }
}