using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class CountdownTimerUpdateAction_RemainingTime : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;
        private static readonly Text RemainingTimeFormat = new TextOf(@"mm\:ss");

        public CountdownTimerUpdateAction_RemainingTime(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            countdownTime.Remaining().Format(RemainingTimeFormat).Into(mainForm.CountDownTextWriter());
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}