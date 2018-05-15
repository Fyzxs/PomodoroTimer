using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Wrappers;

namespace PomodorTimerDesktop.Actions.TimerUpdate
{
    internal sealed class CountdownTimerUpdateAction_DefaultForeColor : ICountdownTimerUpdateAction
    {
        private static readonly ArgbColor Color = new BlackArgbColor();
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_DefaultForeColor(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            Color.Into(mainForm.CountDownForeColorWriter());

            _nextAction.Act(mainForm, countdownTime, more);
        }
    }
}