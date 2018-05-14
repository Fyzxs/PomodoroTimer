using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class CountdownTimerUpdateAction_ShowLongBreakOver : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;
        private static readonly Text SessionOver = new TextOf("Long Break Over!");

        public CountdownTimerUpdateAction_ShowLongBreakOver(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            mainForm.ShowAlert(SessionOver);
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}