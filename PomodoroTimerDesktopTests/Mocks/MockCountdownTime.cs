using InterfaceMocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Time;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockCountdownTime : ICountdownTime
    {
        private MockMethodWithResponse<TimeInterval> _remaining;
        private MockCountdownTime() { }
        public TimeInterval Remaining() => _remaining.Invoke();

        public class Builder
        {
            private readonly MockMethodWithResponse<TimeInterval> _remaining = new MockMethodWithResponse<TimeInterval>("MockCountdownTime#Remaining");

            public MockCountdownTime Build()
            {
                return new MockCountdownTime { _remaining = _remaining };
            }

            public Builder Remaining(params TimeInterval[] responseValues)
            {
                _remaining.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Remaining(params Func<TimeInterval>[] responseValues)
            {
                _remaining.UpdateInvocation(responseValues);
                return this;
            }
        }

        public void AssertRemainingInvoked() => _remaining.AssertInvoked();
    }
}