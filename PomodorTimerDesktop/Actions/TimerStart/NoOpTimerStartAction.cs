using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal sealed class NoOpTimerStartAction : ICountdownTimerStartAction
    {
        public void Act(IMainForm form, CountdownTimer timer) { }
    }
}