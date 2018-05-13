using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers.Delegates;
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

    /*
     * A COMMENT! *GASP!*
     * I had this as a Bool, because it resolves to boolean. But it's not a bool. It's a slug.
     * It needs to resolve to a bool for the bookend, but not a bool.
     * To resolve via the implicit cast can't be an interface... so... no interface.
     */
    internal sealed class TimerAutoReset
    {

        public static readonly TimerAutoReset Repeat = new TimerAutoReset();
        public static readonly TimerAutoReset Single = new TimerAutoReset();

        public static implicit operator bool(TimerAutoReset origin) => origin == Repeat;

        private TimerAutoReset() { }
    }

    public interface ITimerBookEnd
    {
        event TimerElapsedEvent Elapsed;
        void Start();
        void Close();
    }
}