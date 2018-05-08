namespace PomodoroTimerLibTests.Library.Timers
{
    public interface ITimeLeftTimer : ITimer
    {
        event TimerLeftEvent TimeLeft;
    }
}