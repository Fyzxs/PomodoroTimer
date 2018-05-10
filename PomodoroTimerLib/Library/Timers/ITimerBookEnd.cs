namespace PomodoroTimerLib.Library.Timers
{
    public interface ITimerBookEnd
    {
        event TimerElapsedEvent Elapsed;
        void Start();
        void Close();
    }
}