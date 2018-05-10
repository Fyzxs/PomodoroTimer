using PomodoroTimerLib.Library.Cache;
using System;

namespace PomodoroTimerLib.Library.Time.Instant
{
    internal sealed class NowAtFirstAccess : TimeInstant
    {
        private readonly ICacheSync<TimeInstant> _cache;

        public NowAtFirstAccess() : this(new BlockingClassCacheSync<TimeInstant>()) { }
        public NowAtFirstAccess(ICacheSync<TimeInstant> cache) => _cache = cache;

        protected override DateTime Value() => _cache.Retrieve(() => new Now());
    }
}