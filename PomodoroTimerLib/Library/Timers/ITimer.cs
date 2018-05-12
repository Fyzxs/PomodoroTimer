using PomodoroTimerLib.Library.Timers.Delegates;

namespace PomodoroTimerLib.Library.Timers
{
    public interface ITimer
    {
        event TimerElapsedEvent Elapsed;
        void Start();
        void Close();
    }
}