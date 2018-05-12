using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    public sealed class Milliseconds : TimeInterval
    {
        private readonly double _milliseconds;
        public Milliseconds(double milliseconds) => _milliseconds = milliseconds;
        protected override TimeSpan Value() => TimeSpan.FromMilliseconds(_milliseconds);
    }
}