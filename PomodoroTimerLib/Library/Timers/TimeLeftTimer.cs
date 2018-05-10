using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class TimeLeftTimer : ITimeLeftTimer
    {
        private readonly TimeInterval _interval;
        private readonly ITimer _update;
        private readonly ITimer _actual;
        private readonly TimeInterval _startTimeInstant;

        public TimeLeftTimer(TimeInterval interval)
        {
            _interval = interval;
            _startTimeInstant = new NowAtFirstAccessUntil(interval);

            _actual = new SingleEventTimer(interval);
            _actual.Elapsed += Actual_Elapsed;

            _update = new HalfSecondRepeatingEventTimer();
            _update.Elapsed += Update_Elapsed;
        }

        private void Update_Elapsed() => TimeLeft?.Invoke(_startTimeInstant);

        private void Actual_Elapsed()
        {
            Elapsed?.Invoke();
            Close();
        }

        public event TimerLeftEvent TimeLeft;
        public event TimerElapsedEvent Elapsed;
        public void Start()
        {
            _update.Start();
            _actual.Start();
        }

        public void Close()
        {
            _update.Close();
            _actual.Close();
        }
    }
}