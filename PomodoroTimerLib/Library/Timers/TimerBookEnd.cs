using PomodoroTimerLib.Library.Time;
using System.Timers;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class TimerBookEnd : ITimerBookEnd
    {
        private readonly Timer _timer;

        public event TimerElapsedEvent Elapsed;

        /*
         Note: Normally I'd not put a comment for this. It becomes easily xferred knowledge; but for demonstration purposes...
         We're passing in the TimerAutoReset class instead of the base type Bool to enforce meaning in code from the callers.
         TimerAutoReset is a Bool to prevent having duplicate cast code.
        */
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