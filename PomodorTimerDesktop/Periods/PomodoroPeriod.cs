using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate;

namespace PomodorTimerDesktop.Periods
{
    internal abstract class PomodoroPeriod : IPomodoroPeriod
    {
        private readonly ICountdownTimer _timer;
        private readonly ICountdownTimerStartAction _startAction;
        private readonly ICountdownTimerUpdateAction _updateAction;
        private IMainForm _mainForm;

        protected PomodoroPeriod(ICountdownTimer timer, ICountdownTimerStartAction startAction, ICountdownTimerUpdateAction updateAction)
        {
            _timer = timer;
            _startAction = startAction;
            _updateAction = updateAction;

            _timer.TimerEvent += TimerOnTimerEvent;
        }

        public void SetMainForm(IMainForm mainForm) => _mainForm = mainForm;

        private void TimerOnTimerEvent(ICountdownTime countdowntime, TimerProgress ismore) => _updateAction.Act(_mainForm, countdowntime, ismore);

        public void Start() => _startAction.Act(_mainForm, _timer);
    }
    internal interface IPomodoroPeriod
    {
        void SetMainForm(IMainForm mainForm);
        void Start();
    }
}