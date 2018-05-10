using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class TimeLeftTimer : ITimeLeftTimer
    {
        private readonly ITimer _update;
        private readonly ITimer _actual;
        private readonly TimeInterval _startTimeInstant;

        public TimeLeftTimer(TimeInterval interval) : this(new NowAtFirstAccessUntil(interval), new SingleEventTimer(interval), new HalfSecondRepeatingEventTimer()) { }
        public TimeLeftTimer(TimeInterval startTimeInstant, ITimer actual, ITimer update)
        {
            _startTimeInstant = startTimeInstant;

            _actual = actual;
            _actual.Elapsed += Actual_Elapsed;

            _update = update;
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