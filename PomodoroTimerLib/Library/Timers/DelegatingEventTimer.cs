namespace PomodoroTimerLib.Library.Timers
{
    public abstract class DelegatingEventTimer : ITimer
    {
        private readonly ITimerBookEnd _eventTimer;

        protected DelegatingEventTimer(ITimerBookEnd eventTimer)
        {
            _eventTimer = eventTimer;
            _eventTimer.Elapsed += EventTimerOnElapsed;
        }

        public event TimerElapsedEvent Elapsed;

        public void Start() => _eventTimer.Start();

        public void Close() => _eventTimer.Close();

        private void EventTimerOnElapsed() => Elapsed?.Invoke();
    }
}