using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class SessionTimerStartAction : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public SessionTimerStartAction() : this(
            new CountdownTimerStartAction_HideSessionStart(
                new CountdownTimerStartAction_StartTimer(
                    new NoOpTimerStartAction())))
        { }

        private SessionTimerStartAction(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, CountdownTimer timer) => _nextAction.Act(form, timer);
    }
}