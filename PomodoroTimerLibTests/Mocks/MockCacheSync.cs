using InterfaceMocks;
using PomodoroTimerLib.Library.Cache;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockCacheSync<T> : ICacheSync<T>
    {
        private MockMethodWithParamAndResponse<Func<T>, T> _retrieve;
        private MockMethod _clear;
        private MockCacheSync() { }
        public T Retrieve(Func<T> func) => _retrieve.Invoke(func);
        public void Clear() => _clear.Invoke();

        public class Builder
        {
            private readonly MockMethodWithParamAndResponse<Func<T>, T> _retrieve = new MockMethodWithParamAndResponse<Func<T>, T>("MockCacheSync#Retrieve");
            private readonly MockMethod _clear = new MockMethod("MockCacheSync#Clear");

            public MockCacheSync<T> Build()
            {
                return new MockCacheSync<T>
                {
                    _retrieve = _retrieve,
                    _clear = _clear
                };
            }

            public Builder Retrieve(params T[] responseValues)
            {
                _retrieve.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Retrieve(params Func<T>[] responseValues)
            {
                _retrieve.UpdateInvocation(responseValues);
                return this;
            }

            public Builder Clear()
            {
                _clear.UpdateInvocation();
                return this;
            }

            public Builder Clear(params Action[] actions)
            {
                _clear.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertClearInvoked() => _clear.AssertInvoked();
    }
}