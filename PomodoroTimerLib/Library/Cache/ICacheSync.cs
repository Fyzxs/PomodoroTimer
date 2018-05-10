using System;

namespace PomodoroTimerLib.Library.Cache
{
    public interface ICacheSync<T>
    {
        T Retrieve(Func<T> func);
        void Clear();
    }
}