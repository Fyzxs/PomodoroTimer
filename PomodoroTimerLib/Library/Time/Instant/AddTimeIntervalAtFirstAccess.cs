using System;

namespace PomodoroTimerLib.Library.Time.Instant {
    public sealed class AddTimeIntervalAtFirstAccess : TimeInstant
    {
        private readonly TimeInterval _interval;
        private readonly TimeInstant _nowAtFirstAccess;
        public AddTimeIntervalAtFirstAccess(TimeInterval interval) : this(interval, new NowAtFirstAccess()) { }

        public AddTimeIntervalAtFirstAccess(TimeInterval interval, TimeInstant nowAtFirstAccess)
        {
            _interval = interval;
            _nowAtFirstAccess = nowAtFirstAccess;
        }

        protected override DateTime Value() => _nowAtFirstAccess.Add(_interval);
    }
}