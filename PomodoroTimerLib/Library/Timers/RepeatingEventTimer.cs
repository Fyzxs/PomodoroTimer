using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class RepeatingEventTimer : DelegatingEventTimer, IRepeatingEventTimer
    {
        private readonly ICounter _counter;

        public RepeatingEventTimer(TimeInterval interval) : this(new TimerBookEnd(interval, TimerAutoReset.Repeat), new Counter()) { }

        public RepeatingEventTimer(ITimerBookEnd eventTimer, ICounter counter) : base(eventTimer)
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