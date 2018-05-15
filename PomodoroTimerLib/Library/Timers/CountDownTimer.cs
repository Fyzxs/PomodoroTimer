using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    public abstract class CountdownTimer : ICountdownTimer
    {
        private readonly ITimerBookEnd _timerBookEnd;
        private readonly ICountdownTracker _countdownTracker;
        private readonly ICountdownTimerElapsedAction _countdownTimerElapsedAction;

        public event CountdownTimerEvent TimerEvent;

        protected CountdownTimer(TimeInterval interval, TimeInterval precision) : this(
            new CountdownTimerElapsedAction(),
            new TimerBookEnd(precision, TimerAutoReset.Repeat),
            new CountdownTracker(interval, precision))
        { }
        protected CountdownTimer(ICountdownTimerElapsedAction countdownTimerElapsedAction, ITimerBookEnd timerBookEnd, ICountdownTracker countdownTracker)
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
            TimerEvent?.Invoke(_countdownTracker, progress);
        }

        public ICountdownState CountdownState() => _countdownTracker.CountdownState();

        public void Start()
        {
            _countdownTracker.Restart();
            _timerBookEnd.Start();
        }

        public void Stop() => _timerBookEnd.Stop();
    }

    public interface ICountdownTimer
    {
        event CountdownTimerEvent TimerEvent;
        ICountdownState CountdownState();
        void Invoke(TimerProgress progress);
        void Start();
        void Stop();
    }
}