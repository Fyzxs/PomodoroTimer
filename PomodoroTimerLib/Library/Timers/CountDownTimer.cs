using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    //TODO: Remove DelegatingTimer
    public sealed class CountdownTimer : ICountdownTimer
    {
        private readonly Number _events;
        private readonly ICounter _counter;
        private readonly ICountdownTime _countdownTime;
        private readonly ITimerBookEnd _timerBookEnd;

        public event RepeatSpecifiedEvent RepeatSpecified;

        public CountdownTimer(TimeInterval interval, TimeInterval precision) : this(interval, precision, new QuotientOfTimeInterval(interval, precision), new Counter()) { }
        private CountdownTimer(TimeInterval interval, TimeInterval precision, Number events, ICounter counter) : this(events, counter, new CountdownTime(interval, precision, counter), new TimerBookEnd(precision, TimerAutoReset.Repeat)) { }
        private CountdownTimer(Number events, ICounter counter, ICountdownTime countdownTime, ITimerBookEnd timerBookEnd)
        {
            _events = events;
            _counter = counter;
            _countdownTime = countdownTime;
            _timerBookEnd = timerBookEnd;

            _timerBookEnd.Elapsed += OnElapsed;
        }

        //TODO: Chain
        private void OnElapsed()
        {
            ICountdownTimer countdownTimer = this;

            if (countdownTimer.CountdownState().Finished())
            {
                countdownTimer.Close();
                return;
            }

            if (countdownTimer.CountdownState().Last())
            {
                countdownTimer.Invoke(TimerProgress.Last);
                return;
            }

            countdownTimer.Invoke(TimerProgress.More);
        }

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