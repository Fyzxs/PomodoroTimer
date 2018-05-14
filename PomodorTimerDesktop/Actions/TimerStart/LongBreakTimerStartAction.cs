using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart {
    internal sealed class LongBreakTimerStartAction : ICountdownTimerStartAction
    {
        private readonly ICountdownTimerStartAction _nextAction;

        public LongBreakTimerStartAction() : this(
            new CountdownTimerStartAction_StartTimer(
                new CountdownTimerStartAction_HideLongBreakStart(
                    new NoOpTimerStartAction())))
        { }

        private LongBreakTimerStartAction(ICountdownTimerStartAction nextAction) => _nextAction = nextAction;

        public void Act(IMainForm form, CountdownTimer timer) => _nextAction.Act(form, timer);
    }
}