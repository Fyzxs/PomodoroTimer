namespace PomodoroTimerLib.Library.Timers.CountdownActions
{
    public sealed class CountdownTimerElapsedAction : ICountdownTimerElapsedAction
    {
        private readonly ICountdownTimerElapsedAction _nextAction;

        public CountdownTimerElapsedAction() : this(
            new CountdownTimerElapsedAction_FinishedGuard(
                new CountdownTimerElapsedAction_LastGuard(
                    new CountdownTimerElapsedAction_Update(
                        new NoOp()))))
        { }

        public CountdownTimerElapsedAction(ICountdownTimerElapsedAction nextAction) => _nextAction = nextAction;

        public void Act(ICountdownTimer timer) => _nextAction.Act(timer);

        public class NoOp : ICountdownTimerElapsedAction
        {
            public void Act(ICountdownTimer timer) { } // NoOp
        }
    }
}