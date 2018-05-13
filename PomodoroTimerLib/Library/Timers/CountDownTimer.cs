using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    //TODO: Remove DelegatingTimer
    public sealed class CountDownTimer : DelegatingTimer, ICountDownTimer
    {
        private readonly TimeInterval _interval;
        private readonly TimeInterval _precision;
        private readonly Number _events;//TODO: Counter and Events are always used together - High Cohesion Extract
        private readonly ICounter _counter;

        public CountDownTimer(TimeInterval interval, TimeInterval precision) : this(interval, precision, new QuotientOfTimeInterval(interval, precision), new Counter()) { }
        private CountDownTimer(TimeInterval interval, TimeInterval precision, Number events, ICounter counter) : base(new TimerBookEnd(precision, TimerAutoReset.Repeat))
        {
            _interval = interval;
            _precision = precision;
            _events = events;
            _counter = counter;
            Elapsed += OnElapsed;
        }

        //TODO: Chain
        private void OnElapsed()
        {
            if (_events.LessThan(_counter.Value()))
            {
                Close();
                return;
            }

            if (_counter.Value().EqualTo(_events))
            {
                _counter.Increment();
                RepeatSpecified?.Invoke(_interval, _precision.Multiply(_counter.Value()), TimerProgress.Last);
                return;
            }

            _counter.Increment();
            RepeatSpecified?.Invoke(_interval, _precision.Multiply(_counter.Value()), TimerProgress.More);
        }

        public event RepeatSpecifiedEvent RepeatSpecified;
    }

    public interface ICountDownTimer : ITimer
    {
        event RepeatSpecifiedEvent RepeatSpecified;
    }
}