using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodorTimerDesktop.Periods
{
    internal sealed class LongBreakPomodoroPeriod : PomodoroPeriod
    {
        public LongBreakPomodoroPeriod() : //TODO : Make dynamic period
            base(new CountdownTimer(new Seconds(5), new Milliseconds(500)), new LongBreakTimerStartAction(), new LongBreakTimerUpdateAction())
        { }
    }

    internal sealed class LongBreakTimerUpdateAction : ICountdownTimerUpdateAction
    {

        private readonly ICountdownTimerUpdateAction _finished;
        private readonly ICountdownTimerUpdateAction _running;

        public LongBreakTimerUpdateAction() : this(
            new LongBreakTimerUpdateAction_TimerFinished(),
            new CountdownTimerUpdateAction_TimerRunning())
        { }

        public LongBreakTimerUpdateAction(ICountdownTimerUpdateAction finished, ICountdownTimerUpdateAction running)
        {
            _finished = finished;
            _running = running;
        }

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            _finished.Act(mainForm, countdownTime, more);
            _running.Act(mainForm, countdownTime, more);
        }
    }

    internal sealed class LongBreakTimerUpdateAction_TimerFinished : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _nextAction;

        public LongBreakTimerUpdateAction_TimerFinished() : this(
            new CountdownTimerUpdateAction_GuardAgainstMore(
                new CountdownTimerUpdateAction_FinishedForeColor(
                    new CountdownTimerUpdateAction_RemainingTime(
                        new CountdownTimerUpdateAction_ShowLongBreakOver(
                            new CountdownTimerUpdateAction_ShowSessionStart(
                                new CountdownTimerUpdateAction_FormToTop(
                                    new NoOpUpdateAction())))))))
        { }

        public LongBreakTimerUpdateAction_TimerFinished(ICountdownTimerUpdateAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _nextAction.Act(mainForm, countdownTime, more);
    }
}