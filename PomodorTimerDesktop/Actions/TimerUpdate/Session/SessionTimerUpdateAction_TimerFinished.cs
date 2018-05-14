using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.Session
{
    internal sealed class SessionTimerUpdateAction_TimerFinished : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public SessionTimerUpdateAction_TimerFinished() : this(
            new CountdownTimerUpdateAction_GuardAgainstMore(
                new CountdownTimerUpdateAction_FinishedForeColor(
                    new CountdownTimerUpdateAction_RemainingTime(
                        new CountdownTimerUpdateAction_ShowSessionOver(
                            new SessionTimerUpdateAction_ShowNextStart(
                            new CountdownTimerUpdateAction_EnableLongBreakStart(
                                new CountdownTimerUpdateAction_EnableShortBreakStart(
                                    new CountdownTimerUpdateAction_HideSessionStart(
                                            new CountdownTimerUpdateAction_FormToTop(
                                                new NoOpUpdateAction()))))))))))
        { }

        public SessionTimerUpdateAction_TimerFinished(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _nextAction.Act(mainForm, countdownTime, more);
    }
}