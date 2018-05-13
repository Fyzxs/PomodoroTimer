namespace PomodoroTimerLib.Library.Timers.CountdownActions {
    public sealed class CountdownTimerElapsedAction_Update : ICountdownTimerElapsedAction
    {
        private readonly ICountdownTimerElapsedAction _nextAction;

        public CountdownTimerElapsedAction_Update() { }

        public CountdownTimerElapsedAction_Update(ICountdownTimerElapsedAction nextAction) => _nextAction = nextAction;

        public void Act(ICountdownTimer timer)
        {
            timer.Invoke(TimerProgress.More);
            _nextAction.Act(timer);
        }
    }
}