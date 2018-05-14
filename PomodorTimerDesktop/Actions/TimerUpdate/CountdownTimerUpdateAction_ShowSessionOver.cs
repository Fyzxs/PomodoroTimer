using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate
{
    internal sealed class CountdownTimerUpdateAction_ShowSessionOver : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;
        private static readonly Text SessionOver = new TextOf("Session Over! Take a Break!\nYou know it makes the day better.");

        public CountdownTimerUpdateAction_ShowSessionOver(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            mainForm.ShowAlert(SessionOver);
            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}