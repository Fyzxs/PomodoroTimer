using PomodoroTimerLibTests.Library.Time;

namespace PomodoroTimerLibTests.Library.Timers
{
    public abstract class EventTimer : ITimer
    {
        private readonly ITimerBookEnd _timerBookEnd;
        protected EventTimer(Milliseconds interval, TimerBookEndAutoReset autoReset) : this(new TimerBookEnd(interval, autoReset)) { }
        private EventTimer(ITimerBookEnd timerBookEnd)
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