using InterfaceMocks;
using PomodoroTimerLib.Library.Timers;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockTimer : ITimer
    {
        private MockMethod _start;
        private MockMethod _close;
        private MockTimer() { }
        public event TimerElapsedEvent Elapsed;
        public void Start() => _start.Invoke();
        public void Close() => _close.Invoke();

        public class Builder
        {
            private readonly MockMethod _start = new MockMethod("MockTimer#Start");
            private readonly MockMethod _close = new MockMethod("MockTimer#Close");

            public MockTimer Build()
            {
                return new MockTimer
                {
                    _start = _start,
                    _close = _close
                };
            }

            public Builder Start()
            {
                _start.UpdateInvocation();
                return this;
            }

            public Builder Start(params Action[] actions)
            {
                _start.UpdateInvocation(actions);
                return this;
            }

            public Builder Close()
            {
                _close.UpdateInvocation();
                return this;
            }

            public Builder Close(params Action[] actions)
            {
                _close.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertStartInvoked() => _start.AssertInvoked();
        public void AssertCloseInvoked() => _close.AssertInvoked();
        public void TriggerElapsed()
        {
            //TODO: Looks like a "MockEvent" is gonna be needed
            Elapsed.Invoke();
        }
    }
}