using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate
{
    internal sealed class CountdownTimerUpdateAction_ShowLongBreakStart : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_ShowLongBreakStart(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            Show(mainForm, more);
            _nextAction.Act(mainForm, countdownTime, more);
        }

        private static void Show(IMainForm mainForm, TimerProgress more)
        {
            mainForm.LongBreakStartVisibility().Show();
        }
    }
}