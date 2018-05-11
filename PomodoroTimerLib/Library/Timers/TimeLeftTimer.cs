using PomodoroTimerLib.Library.Threading;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library.Timers
{
    //TODO: Potential "DualTimer" class with actual & update
    //TODO: Rename to TimeLeftSingleEventTimer?
    //TODO: Clean up how semaphore is used
    public sealed class TimeLeftTimer : ITimeLeftTimer
    {
        private readonly ITimer _update;
        private readonly ITimer _actual;
        private readonly TimeInterval _startTimeInstant;
        private readonly ISemaphoreSlimBookEnd _semaphore = new SemaphoreSlimBookEnd();

        //TODO: Push this into "SingleEventTimer" as a "HasFired" check.
        private bool _actualFired;

        public TimeLeftTimer(TimeInterval interval) : this(new NowAtFirstAccessUntil(interval), new SingleEventTimer(interval), new HalfSecondRepeatingEventTimer()) { }
        private TimeLeftTimer(TimeInterval startTimeInstant, ITimer actual, ITimer update)
        {
            _startTimeInstant = startTimeInstant;

            _actual = actual;
            _actual.Elapsed += Actual_Elapsed;

            _update = update;
            _update.Elapsed += Update_Elapsed;
        }

        private void Update_Elapsed()
        {
            try
            {
                _semaphore.WaitSync();
                if (_actualFired) return;
                TimeLeft?.Invoke(_startTimeInstant);
            }
            finally
            {
                _semaphore.Release();
            }
        }

        private void Actual_Elapsed()
        {
            TriggerActual();

            Close();
        }

        private void TriggerActual()
        {
            try
            {
                _semaphore.WaitSync();
                _actualFired = true;
                Elapsed?.Invoke();
            }
            finally
            {
                _semaphore.Release();
            }
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
    public interface ITimeLeftTimer : ITimer
    {
        event TimerLeftEvent TimeLeft;
    }
    public interface ITimer
    {
        event TimerElapsedEvent Elapsed;
        void Start();
        void Close();
    }
}