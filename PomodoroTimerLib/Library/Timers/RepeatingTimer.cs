using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class RepeatingTimer : DelegatingTimer, IRepeatingEventTimer
    {
        private readonly ICounter _counter;

        public RepeatingTimer(TimeInterval interval) : this(new TimerBookEnd(interval, TimerAutoReset.Repeat), new Counter()) { }

        private RepeatingTimer(ITimerBookEnd eventTimer, ICounter counter) : base(eventTimer)
        {
            eventTimer.Elapsed += EventTimerOnElapsed;
            _counter = counter;
        }

        public Number ElapsedCount() => _counter.Value();

        private void EventTimerOnElapsed() => _counter.Increment();
    }

    public interface IRepeatingEventTimer : ITimer
    {
        Number ElapsedCount();
    }
}