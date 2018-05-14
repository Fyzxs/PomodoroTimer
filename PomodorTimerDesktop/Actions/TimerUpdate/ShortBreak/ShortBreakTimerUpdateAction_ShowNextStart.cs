using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak {
    internal sealed class ShortBreakTimerUpdateAction_ShowNextStart : ICountdownTimerUpdateAction
    {
        private static readonly Number SessionsToLongBreak = new NumberOf(4);
        private readonly ICountdownTimerUpdateAction _sessionAction;
        private readonly ICountdownTimerUpdateAction _longBreakAction;
        private readonly ICounter _counter;

        public ShortBreakTimerUpdateAction_ShowNextStart(ICountdownTimerUpdateAction nextAction) : this(
            new CountdownTimerUpdateAction_ShowSessionStart(nextAction),
            new CountdownTimerUpdateAction_ShowLongBreakStart(nextAction),
            new Counter())
        { }

        private ShortBreakTimerUpdateAction_ShowNextStart(
            ICountdownTimerUpdateAction sessionAction,
            ICountdownTimerUpdateAction longBreakAction,
            ICounter counter)
        {
            _sessionAction = sessionAction;
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

            _sessionAction.Act(mainForm, countdownTime, more);
        }
        private void ShowLongBreak(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more)
        {
            if (_counter.Value().LessThan(SessionsToLongBreak)) return;

            _longBreakAction.Act(mainForm, countdownTime, more);
        }
    }
}