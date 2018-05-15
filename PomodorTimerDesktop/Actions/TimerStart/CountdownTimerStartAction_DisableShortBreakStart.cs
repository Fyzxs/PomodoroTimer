using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class CountdownTimerStartAction_DisableShortBreakStart : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public CountdownTimerStartAction_DisableShortBreakStart(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, ICountdownTimer timer)
        {
            form.ShortBreakStartEnabled().Disable();
            _nextAction.Act(form, timer);
        }
    }

}