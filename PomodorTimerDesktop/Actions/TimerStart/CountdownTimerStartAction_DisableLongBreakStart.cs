using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class CountdownTimerStartAction_DisableLongBreakStart : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public CountdownTimerStartAction_DisableLongBreakStart(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, CountdownTimer timer)
        {
            form.LongBreakStartEnabled().Disable();
            _nextAction.Act(form, timer);
        }
    }
}