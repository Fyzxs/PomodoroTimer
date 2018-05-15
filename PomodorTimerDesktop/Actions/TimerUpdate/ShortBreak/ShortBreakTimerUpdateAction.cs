using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak
{
    internal sealed class ShortBreakTimerUpdateAction : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _finished;
        private readonly ICountdownTimerUpdateAction _running;

        public ShortBreakTimerUpdateAction() : this(
            new ShortBreakTimerUpdateAction_TimerFinished(),
            new CountdownTimerUpdateAction_TimerRunning())
        { }

        private ShortBreakTimerUpdateAction(ICountdownTimerUpdateAction finished, ICountdownTimerUpdateAction running)
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