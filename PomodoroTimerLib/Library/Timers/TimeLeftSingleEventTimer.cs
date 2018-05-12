using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Threading;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class TimeLeftSingleEventTimer : ITimeLeftTimer
    {
        private readonly ITimer _update;
        private readonly ITimer _actual;
        private readonly TimeInterval _startTimeInstant;
        private readonly ILockAction _lockAction;
        /*
         * Note: It's mutable... I know. I'm not seeing a clean way ATM to de-mutable the behavior. Multiple timers... bleh
         */
        private bool _hasFired;

        public TimeLeftSingleEventTimer(TimeInterval interval) : this(new NowAtFirstAccessUntil(interval), new SingleEventTimer(interval), new HalfSecondRepeatingEventTimer(), new LockAction())
        {
        }

        private TimeLeftSingleEventTimer(TimeInterval startTimeInstant, ITimer actual, ITimer update, ILockAction lockAction)
        {

            _startTimeInstant = startTimeInstant;

            _actual = actual;
            _actual.Elapsed += Actual_Elapsed;

            _update = update;
            _update.Elapsed += Update_Elapsed;


            _lockAction = lockAction;
        }

        private void Update_Elapsed() =>
            _lockAction.Around(() =>
            {
                if (_hasFired) return;
                TimeLeft?.Invoke(_startTimeInstant, Bool.True);
            });

        private void Actual_Elapsed()
        {
            _lockAction.Around(() =>
            {
                _hasFired = true;
                TimeLeft?.Invoke(_startTimeInstant, Bool.False);
                Close();
            });
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

    //TODO: Kill TimeLeftSingleEventTimer in favor of this guy
    public sealed class RepeatSpecifiedEventTimer : DelegatingEventTimer, IRepeatSpecifiedEventTimer
    {
        private readonly TimeInterval _interval;
        private readonly TimeInterval _precision;
        private readonly Number _events;
        private readonly ICounter _counter;

        public RepeatSpecifiedEventTimer(TimeInterval interval, TimeInterval precision) : this(interval, precision, new QuotientOfTimeInterval(interval, precision), new Counter()) { }
        private RepeatSpecifiedEventTimer(TimeInterval interval, TimeInterval precision, Number events, ICounter counter) : base(new TimerBookEnd(precision, TimerAutoReset.Repeat))
        {
            _interval = interval;
            _precision = precision;
            _events = events;
            _counter = counter;
            Elapsed += OnElapsed;
        }

        private void OnElapsed()
        {
            if (_counter.Value().LessThan(_events).Not())
            {
                RepeatSpecified?.Invoke(_interval, _precision.Multiply(_counter.Value()), Bool.False);
                Close();
                return;
            }

            _counter.Increment();
            RepeatSpecified?.Invoke(_interval, _precision.Multiply(_counter.Value()), Bool.True);
        }

        public event RepeatSpecifiedEvent RepeatSpecified;
    }

    public delegate void RepeatSpecifiedEvent(TimeInterval duration, TimeInterval elapsed, Bool more);
    public interface IRepeatSpecifiedEventTimer : ITimer
    {
        event RepeatSpecifiedEvent RepeatSpecified;
    }
    public interface ITimeLeftTimer : ITimer
    {
        event TimerLeftEvent TimeLeft;
    }
}