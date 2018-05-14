using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.Session
{
    internal sealed class SessionTimerUpdateAction_ShowNextStart : ICountdownTimerUpdateAction
    {
        private static readonly Number SessionsToLongBreak = new NumberOf(4);
        private readonly ICountdownTimerUpdateAction _shortBreakAction;
        private readonly ICountdownTimerUpdateAction _longBreakAction;
        private readonly ICounter _counter;

        public SessionTimerUpdateAction_ShowNextStart(ICountdownTimerUpdateAction nextAction) : this(
            new CountdownTimerUpdateAction_ShowShortBreakStart(nextAction),
            new CountdownTimerUpdateAction_ShowLongBreakStart(nextAction),
            new Counter())
        { }

        private SessionTimerUpdateAction_ShowNextStart(
            ICountdownTimerUpdateAction shortBreakAction,
            ICountdownTimerUpdateAction longBreakAction,
            ICounter counter)
        {
            _shortBreakAction = shortBreakAction;
            _longBreakAction = longBreakAction;
            _counter = counter;
        }

        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            _counter.Increment();
            ShowSession(mainForm, countdownTime, more);
            ShowLongBreak(mainForm, countdownTime, more);
        }

        private void ShowSession(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            if (_counter.Value().LessThan(SessionsToLongBreak).Not()) return;

            _shortBreakAction.Act(mainForm, countdownTime, more);
        }
        private void ShowLongBreak(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            if (_counter.Value().LessThan(SessionsToLongBreak)) return;
            _counter.Restart();
            _longBreakAction.Act(mainForm, countdownTime, more);
        }
    }
}