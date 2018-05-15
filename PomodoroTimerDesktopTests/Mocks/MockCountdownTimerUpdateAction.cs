using InterfaceMocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop;
using PomodorTimerDesktop.Actions.TimerUpdate;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockCountdownTimerUpdateAction : ICountdownTimerUpdateAction
    {
        private MockMethodWithParam<Tuple<IMainForm, ICountdownTime, TimerProgress>> _act;
        private MockCountdownTimerUpdateAction() { }
        public void Act(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _act.Invoke(new Tuple<IMainForm, ICountdownTime, TimerProgress>(mainForm, countdownTime, more));

        public class Builder
        {
            private readonly MockMethodWithParam<Tuple<IMainForm, ICountdownTime, TimerProgress>> _act = new MockMethodWithParam<Tuple<IMainForm, ICountdownTime, TimerProgress>>("MockCountdownTimerUpdateAction#Act");

            public MockCountdownTimerUpdateAction Build()
            {
                return new MockCountdownTimerUpdateAction { _act = _act };
            }

            public Builder Act()
            {
                _act.UpdateInvocation();
                return this;
            }

            public Builder Act(params Action[] actions)
            {
                _act.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertActInvokedWith(IMainForm mainForm, ICountdownTime countdownTime, TimerProgress more) => _act.AssertInvokedWith(new Tuple<IMainForm, ICountdownTime, TimerProgress>(mainForm, countdownTime, more));
    }
}