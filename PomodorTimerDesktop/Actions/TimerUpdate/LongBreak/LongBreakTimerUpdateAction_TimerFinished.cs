using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.LongBreak
{
    internal sealed class LongBreakTimerUpdateAction_TimerFinished : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public LongBreakTimerUpdateAction_TimerFinished() : this(
            new CountdownTimerUpdateAction_GuardAgainstMore(
                new CountdownTimerUpdateAction_FinishedForeColor(
                    new CountdownTimerUpdateAction_RemainingTime(
                        new CountdownTimerUpdateAction_ShowLongBreakOver(
                            new CountdownTimerUpdateAction_EnableSessionStart(
                                new CountdownTimerUpdateAction_HideLongBreakStart(
                                    new CountdownTimerUpdateAction_ShowSessionStart(
                                        new CountdownTimerUpdateAction_FormToTop(
                                            new NoOpUpdateAction())))))))))
        { }

        public LongBreakTimerUpdateAction_TimerFinished(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _nextAction.Act(mainForm, countdownTime, more);
    }
}