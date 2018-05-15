using InterfaceMocks;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop;
using PomodorTimerDesktop.Actions.TimerStart;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockCountdownTimerStartAction : ICountdownTimerStartAction
    {
        private MockMethodWithParam<Tuple<IMainForm, ICountdownTimer>> _act;
        private MockCountdownTimerStartAction() { }
        public void Act(IMainForm form, ICountdownTimer timer) => _act.Invoke(new Tuple<IMainForm, ICountdownTimer>(form, timer));

        public class Builder
        {
            private readonly MockMethodWithParam<Tuple<IMainForm, ICountdownTimer>> _act = new MockMethodWithParam<Tuple<IMainForm, ICountdownTimer>>("MockCountdownTimerStartAction#Act");

            public MockCountdownTimerStartAction Build()
            {
                return new MockCountdownTimerStartAction { _act = _act };
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

        public void AssertActInvokedWith(IMainForm form, ICountdownTimer timer) => _act.AssertInvokedWith(new Tuple<IMainForm, ICountdownTimer>(form, timer));
    }
}