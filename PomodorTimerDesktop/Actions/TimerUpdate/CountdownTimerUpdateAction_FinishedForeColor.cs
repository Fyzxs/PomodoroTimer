using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Wrappers;

namespace PomodorTimerDesktop.Actions.TimerUpdate {
    internal sealed class CountdownTimerUpdateAction_FinishedForeColor : ICountdownTimerUpdateAction
    {
        private static readonly ArgbColor Color = new RedArgbColor();
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_FinishedForeColor(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            ForeColor(mainForm, more);

            _nextAction.Act(mainForm, countdownTime, more);
        }

        private static void ForeColor(IMainForm mainForm, TimerProgress more)
        {
            if (more.AsBool()) return;

            Color.Into(mainForm.CountDownForeColorWriter());
        }
    }
}