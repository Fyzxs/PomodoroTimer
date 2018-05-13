using InterfaceMocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Bools;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockCountdownState : ICountdownState
    {
        private MockMethodWithResponse<Bool> _finished;
        private MockMethodWithResponse<Bool> _last;
        private MockCountdownState() { }
        public Bool Finished() => _finished.Invoke();
        public Bool Last() => _last.Invoke();

        public class Builder
        {
            private readonly MockMethodWithResponse<Bool> _finished = new MockMethodWithResponse<Bool>("MockCountdownState#Finished");
            private readonly MockMethodWithResponse<Bool> _last = new MockMethodWithResponse<Bool>("MockCountdownState#Last");

            public MockCountdownState Build()
            {
                return new MockCountdownState
                {
                    _finished = _finished,
                    _last = _last
                };
            }

            public Builder Finished(params Bool[] responseValues)
            {
                _finished.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Finished(params Func<Bool>[] responseValues)
            {
                _finished.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Last(params Bool[] responseValues)
            {
                _last.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Last(params Func<Bool>[] responseValues)
            {
                _last.UpdateInvocation(responseValues);
                return this;
            }
        }

        public void AssertFinishedInvoked() => _finished.AssertInvoked();
        public void AssertLastInvoked() => _last.AssertInvoked();
    }
}