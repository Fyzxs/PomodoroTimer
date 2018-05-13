using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    public sealed class Seconds : TimeInterval
    {
        private readonly double _seconds;
        public Seconds(double seconds) => _seconds = seconds;
        protected override TimeSpan Value() => TimeSpan.FromSeconds(_seconds);
    }

    public sealed class Minutes : TimeInterval
    {
        private readonly double _minutes;
        public Minutes(double minutes) => _minutes = minutes;
        protected override TimeSpan Value() => TimeSpan.FromMinutes(_minutes);
    }
}