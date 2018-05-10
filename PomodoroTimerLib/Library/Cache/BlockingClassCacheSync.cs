using PomodoroTimerLib.Library.Threading;
using System;

namespace PomodoroTimerLib.Library.Cache
{
    public class BlockingClassCacheSync<T> : ICacheSync<T> where T : class
    {
        private readonly ISemaphoreSlimBookEnd _semaphore;
        private readonly ICacheSync<T> _cache;

        public BlockingClassCacheSync() : this(new SemaphoreSlimBookEnd(), new ClassCacheSync<T>()) { }

        public BlockingClassCacheSync(ISemaphoreSlimBookEnd semaphore, ICacheSync<T> cache)
        {
            _semaphore = semaphore;
            _cache = cache;
        }

        public T Retrieve(Func<T> func)
        {
            try
            {
                _semaphore.WaitSync();
                return _cache.Retrieve(func);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        public void Clear()
        {
            try
            {
                _semaphore.WaitSync();
                _cache.Clear();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}