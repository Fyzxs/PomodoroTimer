using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Primitives.Bools;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class RepeatSpecifiedTimesTimer : DelegatingTimer, IRepeatSpecifiedTimesTimer
    {
        private readonly TimeInterval _interval;
        private readonly TimeInterval _precision;
        private readonly Number _events;
        private readonly ICounter _counter;

        public RepeatSpecifiedTimesTimer(TimeInterval interval, TimeInterval precision) : this(interval, precision, new QuotientOfTimeInterval(interval, precision), new Counter()) { }
        private RepeatSpecifiedTimesTimer(TimeInterval interval, TimeInterval precision, Number events, ICounter counter) : base(new TimerBookEnd(precision, TimerAutoReset.Repeat))
        {
            _interval = interval;
            _precision = precision;
            _events = events;
            _counter = counter;
            Elapsed += OnElapsed;
        }

        private void OnElapsed()
        {
            if (_counter.Value().LessThan(_events).Not())
            {
                RepeatSpecified?.Invoke(_interval, _precision.Multiply(_counter.Value()), Bool.False);
                Close();
                return;
            }

            _counter.Increment();
            RepeatSpecified?.Invoke(_interval, _precision.Multiply(_counter.Value()), Bool.True);
        }

        public event RepeatSpecifiedEvent RepeatSpecified;
    }

    public interface IRepeatSpecifiedTimesTimer : ITimer
    {
        event RepeatSpecifiedEvent RepeatSpecified;
    }
}