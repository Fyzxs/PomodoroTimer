using PomodoroTimerLib.Library.Primitives;
using System.Threading;

namespace PomodoroTimerLib.Library
{
    public class Counter : ICounter
    {
        private long _count;

        public Number Value() => new NumberOf(Interlocked.Read(ref _count));

        public void Increment() => Interlocked.Increment(ref _count);
    }

    public interface ICounter
    {
        void Increment();
        Number Value();
    }
}