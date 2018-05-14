using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart {
    internal sealed class CountdownTimerStartAction_HideLongBreakStart : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public CountdownTimerStartAction_HideLongBreakStart(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, CountdownTimer timer)
        {
            form.LongBreakStartVisibility().Hide();
            _nextAction.Act(form, timer);
        }
    }
}