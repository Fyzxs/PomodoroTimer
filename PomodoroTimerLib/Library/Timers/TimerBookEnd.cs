using PomodoroTimerLib.Library.Primitives;
using System.Timers;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class TimerBookEnd : ITimerBookEnd
    {
        private readonly Timer _timer;

        public event TimerElapsedEvent Elapsed;

        public TimerBookEnd(DoubleNumber interval, TimerBookEndAutoReset autoReset) : this(new Timer(interval), autoReset) { }

        private TimerBookEnd(Timer timer, TimerBookEndAutoReset autoReset)
        {
            _timer = timer;
            _timer.Elapsed += OnElapsed;
            _timer.AutoReset = autoReset;
        }

        public void Start() => _timer.Start();
        public void Close() => _timer.Close();

        private void OnElapsed(object sender, ElapsedEventArgs e) => Elapsed?.Invoke();
    }
}