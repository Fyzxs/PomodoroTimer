using System;

namespace PomodoroTimerLib.Library.Time.Instant
{
    internal sealed class Now : TimeInstant
    {
        private readonly DateTime _now;
        public Now() : this((DateTime)DateTime.Now) { }

        private Now(DateTime now) => _now = now;

        protected override DateTime Value() => _now;
    }
}