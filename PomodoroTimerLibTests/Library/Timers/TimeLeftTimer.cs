using PomodoroTimerLibTests.Library.Time;
using PomodoroTimerLibTests.Library.Time.Instant;

namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class TimeLeftTimer : ITimeLeftTimer
    {
        private readonly Milliseconds _interval;
        private readonly ITimer _update;
        private readonly ITimer _actual;
        private readonly TimeInstant _startTimeInstant;

        public TimeLeftTimer(Milliseconds interval)
        {
            _interval = interval;
            _startTimeInstant = new InstantOfFirstAccess();

            _actual = new SingleEventTimer(interval);
            _actual.Elapsed += Actual_Elapsed;

            _update = new HalfSecondRepeatingEventTimer();
            _update.Elapsed += Update_Elapsed;
        }

        private void Update_Elapsed()
        {
            //Todo: TimeUntilFuture for these two linse
            TimeInstant futureInstant = _startTimeInstant.AddMilliseconds(_interval);
            TimeInterval timeInterval = futureInstant.Until();

            TimeLeft?.Invoke(timeInterval);
        }

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