namespace PomodoroTimerLib.Library.Timers.CountdownActions {
    public interface ICountdownTimerElapsedAction
    {
        void Act(ICountdownTimer timer);
    }
}