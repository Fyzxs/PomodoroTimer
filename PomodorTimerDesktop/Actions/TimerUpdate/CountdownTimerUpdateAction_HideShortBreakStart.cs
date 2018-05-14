using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class CountdownTimerUpdateAction_HideShortBreakStart : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_HideShortBreakStart(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            mainForm.ShortBreakStartVisibility().Hide();
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}