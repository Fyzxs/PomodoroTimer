using System;

namespace PomodoroTimerLib.Library.Threading
{
    //TODO: Delete me
    public sealed class LockAction : ILockAction
    {
        private readonly ISemaphoreSlimBookEnd _semaphoreSlimBookEnd;
        public LockAction() : this(new SemaphoreSlimBookEnd()) { }

        public LockAction(ISemaphoreSlimBookEnd semaphoreSlimBookEnd) => _semaphoreSlimBookEnd = semaphoreSlimBookEnd;

        public void Around(Action action)
        {
            try
            {
                _semaphoreSlimBookEnd.WaitSync();
                action();
            }
            finally
            {
                _semaphoreSlimBookEnd.Release();
            }
        }
    }

    public interface ILockAction
    {
        void Around(Action action);
    }

}