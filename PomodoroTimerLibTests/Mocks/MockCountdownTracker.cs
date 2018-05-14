using InterfaceMocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using PomodoroTimerLib.Library.Time;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockCountdownTracker : ICountdownTracker
    {
        private MockMethodWithResponse<ICountdownState> _countdownState;
        private MockCountdownTracker() { }
        public ICountdownState CountdownState() => _countdownState.Invoke();
        private MockMethod _increment;
        private MockMethodWithResponse<Number> _value;
        private MockMethod _restart;
        public void Increment() => _increment.Invoke();
        public Number Value() => _value.Invoke();
        public void Restart() => _restart.Invoke();

        public class Builder
        {
            private readonly MockMethod _increment = new MockMethod("MockCounter#Increment");
            private readonly MockMethodWithResponse<Number> _value = new MockMethodWithResponse<Number>("MockCounter#Value");
            private readonly MockMethod _restart = new MockMethod("MockCounter#Restart");

            private readonly MockMethodWithResponse<ICountdownState> _countdownState = new MockMethodWithResponse<ICountdownState>("MockCountdownTracker#CountdownState");

            public MockCountdownTracker Build()
            {
                return new MockCountdownTracker
                {
                    _countdownState = _countdownState,
                    _increment = _increment,
                    _value = _value,
                    _restart = _restart
                };
            }

            public Builder Increment()
            {
                _increment.UpdateInvocation();
                return this;
            }

            public Builder Increment(params Action[] actions)
            {
                _increment.UpdateInvocation(actions);
                return this;
            }

            public Builder Value(params Number[] responseValues)
            {
                _value.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Value(params Func<Number>[] responseValues)
            {
                _value.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Restart()
            {
                _restart.UpdateInvocation();
                return this;
            }

            public Builder Restart(params Action[] actions)
            {
                _restart.UpdateInvocation(actions);
                return this;
            }

            public Builder CountdownState(params ICountdownState[] responseValues)
            {
                _countdownState.UpdateInvocation(responseValues);
                return this;
            }

            public Builder CountdownState(params Func<ICountdownState>[] responseValues)
            {
                _countdownState.UpdateInvocation(responseValues);
                return this;
            }
        }

        public void AssertCountdownStateInvoked() => _countdownState.AssertInvoked();

        public void AssertIncrementInvoked() => _increment.AssertInvoked();
        public void AssertValueInvoked() => _value.AssertInvoked();
        public void AssertRestartInvoked() => _restart.AssertInvoked();

        public TimeInterval Remaining() => throw new NotImplementedException();
    }
}