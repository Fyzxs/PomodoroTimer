using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLib.Library
{
    public sealed class CountdownTime : ICountdownTime
    {
        private readonly TimeInterval _interval;
        private readonly TimeInterval _elapsed;
        public CountdownTime(TimeInterval interval, TimeInterval precision, ICounter counter) : this(interval, new ElapsedTimeIntervals(precision, counter)) { }


        public CountdownTime(TimeInterval interval, TimeInterval elapsed)
        {
            _interval = interval;
            _elapsed = elapsed;
        }

        public TimeInterval Remaining() => _interval.Subtract(_elapsed);
    }

    public interface ICountdownTime
    {
        TimeInterval Remaining();
    }
}