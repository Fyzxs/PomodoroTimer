namespace PomodoroTimerLib.Library.Timers.CountdownActions {
    public sealed class CountdownTimerElapsedAction_LastGuard : ICountdownTimerElapsedAction
    {
        private readonly ICountdownTimerElapsedAction _nextAction;

        public CountdownTimerElapsedAction_LastGuard() { }

        public CountdownTimerElapsedAction_LastGuard(ICountdownTimerElapsedAction nextAction) => _nextAction = nextAction;

        public void Act(ICountdownTimer timer)
        {
            if (timer.CountdownState().Last().Not())
            {
                _nextAction.Act(timer);
                return;
            }
            timer.Invoke(TimerProgress.Last);
        }
    }
}