using System;

namespace PomodoroTimerLibTests.Library.Cache
{
    public class ClassCacheSync<T> : ICacheSync<T> where T : class
    {
        private T _cache;
        public T Retrieve(Func<T> func) => _cache ?? (_cache = func());
        public void Clear() => _cache = null;
    }
}