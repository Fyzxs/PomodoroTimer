using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate
{
    internal sealed class CountdownTimerUpdateAction_TimerRunning : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public CountdownTimerUpdateAction_TimerRunning() : this(
            new CountdownTimerUpdateAction_GuardAgainstNoMore(
                new CountdownTimerUpdateAction_DefaultForeColor(
                    new CountdownTimerUpdateAction_RemainingTime(
                        new NoOpUpdateAction()))))
        { }

        private CountdownTimerUpdateAction_TimerRunning(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _nextAction.Act(mainForm, countdownTime, more);
    }
}