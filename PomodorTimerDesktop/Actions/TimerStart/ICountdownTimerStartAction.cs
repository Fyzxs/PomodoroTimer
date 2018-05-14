using PomodoroTimerLib.Library.Timers;

namespace PomodorTimerDesktop.Actions.TimerStart
{
    internal interface ICountdownTimerStartAction
    {
        void Act(IMainForm form, CountdownTimer timer);
    }
}