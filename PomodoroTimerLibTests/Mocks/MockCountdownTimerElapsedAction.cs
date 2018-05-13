using InterfaceMocks;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLib.Library.Timers.CountdownActions;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockCountdownTimerElapsedAction : ICountdownTimerElapsedAction
    {
        private MockMethodWithParam<ICountdownTimer> _act;
        private MockCountdownTimerElapsedAction() { }
        public void Act(ICountdownTimer timer) => _act.Invoke(timer);

        public class Builder
        {
            private readonly MockMethodWithParam<ICountdownTimer> _act = new MockMethodWithParam<ICountdownTimer>("MockCountdownTimerElapsedAction#Act");

            public MockCountdownTimerElapsedAction Build()
            {
                return new MockCountdownTimerElapsedAction { _act = _act };
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

        public void AssertActInvokedWith(ICountdownTimer timer) => _act.AssertInvokedWith(timer);
    }
}