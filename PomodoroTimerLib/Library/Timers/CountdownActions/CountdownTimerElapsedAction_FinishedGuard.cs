namespace PomodoroTimerLib.Library.Timers.CountdownActions
{
    public sealed class CountdownTimerElapsedAction_FinishedGuard : ICountdownTimerElapsedAction
    {
        private readonly ICountdownTimerElapsedAction _nextAction;

        public CountdownTimerElapsedAction_FinishedGuard() { }

        public CountdownTimerElapsedAction_FinishedGuard(ICountdownTimerElapsedAction nextAction) => _nextAction = nextAction;

        public void Act(ICountdownTimer timer)
        {
            if (timer.CountdownState().Finished().Not())
            {
                _nextAction.Act(timer);
                return;
            }
            timer.Stop();
        }
    }
}