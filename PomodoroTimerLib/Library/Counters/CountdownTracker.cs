using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library.Counters
{
    public class CountdownTracker : ICountdownTracker
    {
        private readonly ICounter _counter;
        private readonly Number _events;
        private readonly ICountdownTime _countdownTime;

        public CountdownTracker(TimeInterval interval, TimeInterval precision) : this(interval, precision, new Counter(), new QuotientOfTimeInterval(interval, precision)) { }

        private CountdownTracker(TimeInterval interval, TimeInterval precision, ICounter counter, Number events) : this(counter, events, new CountdownTime(interval, precision, counter))
        { }

        private CountdownTracker(ICounter counter, Number events, ICountdownTime countdownTime)
        {
            _counter = counter;
            _events = events;
            _countdownTime = countdownTime;
        }

        public TimeInterval Remaining() => _countdownTime.Remaining();

        public void Increment() => _counter.Increment();

        public Number Value() => _counter.Value();

        public ICountdownState CountdownState() => new CountdownState(_events, _counter);
        public void Restart() => _counter.Restart();
    }

    public interface ICountdownTracker : ICountdownTime, ICounter
    {
        ICountdownState CountdownState();
    }
}