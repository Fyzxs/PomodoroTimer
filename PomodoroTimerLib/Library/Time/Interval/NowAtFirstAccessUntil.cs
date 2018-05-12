using PomodoroTimerLib.Library.Time.Instant;
using System;

namespace PomodoroTimerLib.Library.Time.Interval
{
    public sealed class NowAtFirstAccessUntil : TimeInterval
    {
        private readonly TimeInstant _timeInstant;

        public NowAtFirstAccessUntil(TimeInterval interval) : this(new AddTimeIntervalAtFirstAccess(interval)) { }

        private NowAtFirstAccessUntil(TimeInstant timeInstant) => _timeInstant = timeInstant;

        protected override TimeSpan Value() => _timeInstant.Until();
    }
}