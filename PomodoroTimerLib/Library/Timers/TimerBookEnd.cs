using PomodoroTimerLib.Library.Time;
using System.Timers;

namespace PomodoroTimerLib.Library.Timers
{
    internal sealed class TimerBookEnd : ITimerBookEnd
    {
        private readonly Timer _timer;

        public event TimerElapsedEvent Elapsed;

        public TimerBookEnd(TimeInterval interval, TimerAutoReset autoReset) : this(new Timer(interval.Milliseconds()), autoReset) { }

        private TimerBookEnd(Timer timer, TimerAutoReset autoReset)
        {
            _timer = timer;
            _timer.Elapsed += OnElapsed;
            _timer.AutoReset = autoReset;
        }

        public void Start() => _timer.Start();
        public void Close() => _timer.Close();

        private void OnElapsed(object sender, ElapsedEventArgs e) => Elapsed?.Invoke();
    }

    public interface ITimerBookEnd
    {
        event TimerElapsedEvent Elapsed;
        void Start();
        void Close();
    }
}