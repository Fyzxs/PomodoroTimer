using InterfaceMocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Numbers;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockCounter : ICounter
    {
        private MockMethod _increment;
        private MockMethodWithResponse<Number> _value;
        private MockCounter() { }
        public void Increment() => _increment.Invoke();
        public Number Value() => _value.Invoke();

        public class Builder
        {
            private readonly MockMethod _increment = new MockMethod("MockCounter#Increment");
            private readonly MockMethodWithResponse<Number> _value = new MockMethodWithResponse<Number>("MockCounter#Value");

            public MockCounter Build()
            {
                return new MockCounter
                {
                    _increment = _increment,
                    _value = _value
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
        }

        public void AssertIncrementInvoked() => _increment.AssertInvoked();
        public void AssertValueInvoked() => _value.AssertInvoked();
    }
}