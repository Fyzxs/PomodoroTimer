using PomodoroTimerLib.Library.Cache;
using System;

namespace PomodoroTimerLib.Library.Time.Instant
{
    internal sealed class InstantOfFirstAccess : TimeInstant
    {
        private readonly ICacheSync<TimeInstant> _cache;

        public InstantOfFirstAccess() : this(new BlockingClassCacheSync<TimeInstant>()) { }
        public InstantOfFirstAccess(ICacheSync<TimeInstant> cache) => _cache = cache;

        protected override DateTime Value() => _cache.Retrieve(() => new Now());
    }
}