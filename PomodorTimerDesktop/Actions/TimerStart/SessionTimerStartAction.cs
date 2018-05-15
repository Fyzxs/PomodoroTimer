using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class SessionTimerStartAction : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public SessionTimerStartAction() : this(
            new CountdownTimerStartAction_DisableSessionStart(
                new CountdownTimerStartAction_StartTimer(
                    new NoOpTimerStartAction())))
        { }

        private SessionTimerStartAction(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, ICountdownTimer timer) => _nextAction.Act(form, timer);
    }
}