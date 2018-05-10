using PomodoroTimerLib.Library.Time.Instant;
using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    internal sealed class NowUntil : TimeInterval
    {
        private readonly TimeInterval _timeInterval;

        public NowUntil(TimeInstant target) : this(target, new Now()) { }
        private NowUntil(TimeInstant target, TimeInstant now) : this(new DifferenceOfTimeInstant(target, now)) { }
        private NowUntil(TimeInterval timeInterval) => _timeInterval = timeInterval;

        protected override TimeSpan Value() => _timeInterval;
    }
}