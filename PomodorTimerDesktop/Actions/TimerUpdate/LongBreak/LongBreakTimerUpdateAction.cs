using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.LongBreak {
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
}