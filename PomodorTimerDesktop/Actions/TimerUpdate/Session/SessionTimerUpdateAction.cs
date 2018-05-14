using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerUpdate.Session
{
    internal sealed class SessionTimerUpdateAction : ICountdownTimerUpdateAction
    {
        private readonly ICountdownTimerUpdateAction _finished;
        private readonly ICountdownTimerUpdateAction _running;

        public SessionTimerUpdateAction() : this(
            new SessionTimerUpdateAction_TimerFinished(),
            new CountdownTimerUpdateAction_TimerRunning())
        { }

        public SessionTimerUpdateAction(ICountdownTimerUpdateAction finished, ICountdownTimerUpdateAction running)
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