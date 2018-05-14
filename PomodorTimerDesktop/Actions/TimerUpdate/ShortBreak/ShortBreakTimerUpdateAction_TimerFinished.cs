using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak {
    internal sealed class ShortBreakTimerUpdateAction_TimerFinished : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public ShortBreakTimerUpdateAction_TimerFinished() : this(
            new CountdownTimerUpdateAction_GuardAgainstMore(
                new CountdownTimerUpdateAction_FinishedForeColor(
                    new CountdownTimerUpdateAction_RemainingTime(
                        new CountdownTimerUpdateAction_ShowShortBreakOver(
                            new ShortBreakTimerUpdateAction_ShowNextStart(
                                new CountdownTimerUpdateAction_FormToTop(
                                    new NoOpUpdateAction())))))))
        { }

        public ShortBreakTimerUpdateAction_TimerFinished(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _nextAction.Act(mainForm, countdownTime, more);
    }
}