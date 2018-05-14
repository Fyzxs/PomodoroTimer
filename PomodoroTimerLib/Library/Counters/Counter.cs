using PomodoroTimerLib.Library.Primitives.Numbers;
using System.Threading;

namespace PomodoroTimerLib.Library.Counters
{
    public class Counter : ICounter
    {
        private long _count;

        public Number Value() => new NumberOf(Interlocked.Read(ref _count));

        public void Restart() => Interlocked.Exchange(ref _count, 0);

        public void Increment() => Interlocked.Increment(ref _count);
    }
}