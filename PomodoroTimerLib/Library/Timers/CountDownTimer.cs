using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class CountdownTimer : ICountdownTimer
    {
        private readonly ITimerBookEnd _timerBookEnd;
        private readonly ICountdownTracker _countdownTracker;
        private readonly ICountdownTimerElapsedAction _countdownTimerElapsedAction;

        public event RepeatSpecifiedEvent RepeatSpecified;

        public CountdownTimer(TimeInterval interval, TimeInterval precision) : this(
            new CountdownTimerElapsedAction(),
            new TimerBookEnd(precision, TimerAutoReset.Repeat),
            new CountdownTracker(interval, precision))
        { }
        private CountdownTimer(ICountdownTimerElapsedAction countdownTimerElapsedAction, ITimerBookEnd timerBookEnd, ICountdownTracker countdownTracker)
        {
            _timerBookEnd = timerBookEnd;
            _countdownTracker = countdownTracker;
            _countdownTimerElapsedAction = countdownTimerElapsedAction;

            _timerBookEnd.Elapsed += OnElapsed;
        }

        private void OnElapsed() => _countdownTimerElapsedAction.Act(this);

        public void Invoke(TimerProgress progress)
        {
            _countdownTracker.Increment();
            RepeatSpecified?.Invoke(_countdownTracker, progress);
        }

        public ICountdownState CountdownState() => _countdownTracker.CountdownState();

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