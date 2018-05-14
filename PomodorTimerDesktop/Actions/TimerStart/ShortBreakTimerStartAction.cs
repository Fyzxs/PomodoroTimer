using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class ShortBreakTimerStartAction : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public ShortBreakTimerStartAction() : this(
            new CountdownTimerStartAction_StartTimer(
                new CountdownTimerStartAction_DisableShortBreakStart(
                    new NoOpTimerStartAction())))
        { }

        private ShortBreakTimerStartAction(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, CountdownTimer timer) => _nextAction.Act(form, timer);
    }
}