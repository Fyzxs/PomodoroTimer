using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class CountdownTimer : ICountdownTimer
    {
        private readonly Number _events;
        private readonly ICounter _counter;
        private readonly ICountdownTime _countdownTime;
        private readonly ITimerBookEnd _timerBookEnd;
        private readonly ICountdownTimerElapsedAction _countdownTimerElapsedAction;

        public event RepeatSpecifiedEvent RepeatSpecified;

        public CountdownTimer(TimeInterval interval, TimeInterval precision) : this(interval, precision, new QuotientOfTimeInterval(interval, precision), new Counter()) { }
        private CountdownTimer(TimeInterval interval, TimeInterval precision, Number events, ICounter counter) :
            this(events, counter, new CountdownTime(interval, precision, counter), new CountdownTimerElapsedAction(), new TimerBookEnd(precision, TimerAutoReset.Repeat))
        { }
        private CountdownTimer(Number events, ICounter counter, ICountdownTime countdownTime, ICountdownTimerElapsedAction countdownTimerElapsedAction, ITimerBookEnd timerBookEnd)
        {
            /* TODO: This is really busy. Thinking of creating a class like
                class CountdownTracker
                    ctor(interval, precision) => new Counter(), new QuotientOfTimeInterval
                    ICountdownState => new CountdownState(_events, _counter)
                    ICountdownTime => new CountdownTime(interval, precision, counter)

                OR
                class CountdownTracker, ICountdownTime, ICountdownState
                    ctor(interval, precision) => new Counter(), new QuotientOfTimeInterval => new CountdownState(events, counter), new CountdownTime(interval, precision, counter)
                    void Increment() => _counter.Inc();
                    
             */
            _events = events;
            _counter = counter;
            _countdownTime = countdownTime;
            _timerBookEnd = timerBookEnd;
            _countdownTimerElapsedAction = countdownTimerElapsedAction;

            _timerBookEnd.Elapsed += OnElapsed;
        }

        private void OnElapsed() => _countdownTimerElapsedAction.Act(this);

        public void Invoke(TimerProgress progress)
        {
            _counter.Increment();
            RepeatSpecified?.Invoke(_countdownTime, progress);
        }

        public ICountdownState CountdownState() => new CountdownState(_events, _counter);

        public void Start() => _timerBookEnd.Start();

        public void Close() => _timerBookEnd.Close();
    }

    public interface ICountdownTimer
    {
        event RepeatSpecifiedEvent RepeatSpecified;
        ICountdownState CountdownState();
        void Invoke(TimerProgress progress);
        void Start();
        void Close();
    }
}