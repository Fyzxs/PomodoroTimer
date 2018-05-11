using PomodoroTimerLib.Library.Time;

namespace PomodoroTimerLib.Library.Timers
{
    public abstract class EventTimer : ITimer
    {
        private readonly ITimerBookEnd _timerBookEnd;
        protected EventTimer(TimeInterval interval, TimerAutoReset autoReset) : this(new TimerBookEnd(interval, autoReset)) { }
        protected EventTimer(ITimerBookEnd timerBookEnd)
        {
            _timerBookEnd = timerBookEnd;
            _timerBookEnd.Elapsed += OnElapsed;
        }

        private void OnElapsed() => Elapsed?.Invoke();

        public event TimerElapsedEvent Elapsed;
        public void Start() => _timerBookEnd.Start();
        public void Close() => _timerBookEnd.Close();
    }
}