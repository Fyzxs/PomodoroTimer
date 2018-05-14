using PomodoroTimerLib.Library.Primitives.Numbers;

namespace PomodoroTimerLib.Library.Counters
{


    public interface ICounter
    {
        void Increment();
        Number Value();
        void Restart();
    }
}