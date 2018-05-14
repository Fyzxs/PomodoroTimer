using InterfaceMocks;
using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Timers;
using PomodoroTimerLib.Library.Timers.Delegates;
using System;

namespace PomodoroTimerLibTests.Mocks
{
    public partial class MockCountdownTimer : ICountdownTimer
    {
        private MockMethodWithResponse<ICountdownState> _countdownState;
        private MockMethodWithParam<TimerProgress> _invoke;
        private MockMethod _start;
        private MockMethod _close;
        private MockCountdownTimer() { }
        public event RepeatSpecifiedEvent RepeatSpecified;
        public ICountdownState CountdownState() => _countdownState.Invoke();
        public void Invoke(TimerProgress progress) => _invoke.Invoke(progress);
        public void Start() => _start.Invoke();
        public void Stop() => _close.Invoke();

        public class Builder
        {
            private readonly MockMethodWithResponse<ICountdownState> _countdownState = new MockMethodWithResponse<ICountdownState>("MockCountdownTimer#CountdownState");
            private readonly MockMethodWithParam<TimerProgress> _invoke = new MockMethodWithParam<TimerProgress>("MockCountdownTimer#Invoke");
            private readonly MockMethod _start = new MockMethod("MockCountdownTimer#Start");
            private readonly MockMethod _close = new MockMethod("MockCountdownTimer#Close");

            public MockCountdownTimer Build()
            {
                return new MockCountdownTimer
                {
                    _countdownState = _countdownState,
                    _invoke = _invoke,
                    _start = _start,
                    _close = _close
                };
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

            public Builder Invoke()
            {
                _invoke.UpdateInvocation();
                return this;
            }

            public Builder Invoke(params Action[] actions)
            {
                _invoke.UpdateInvocation(actions);
                return this;
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
        public void TriggerElapsed(ICountdownTime countdownTime, TimerProgress isMore)
        {
            //TODO: Looks like a "MockEvent" is gonna be needed
            RepeatSpecified.Invoke(countdownTime, isMore);
        }

        public void AssertCountdownStateInvoked() => _countdownState.AssertInvoked();
        public void AssertInvokeInvokedWith(TimerProgress progress) => _invoke.AssertInvokedWith(progress);
        public void AssertStartInvoked() => _start.AssertInvoked();
        public void AssertCloseInvoked() => _close.AssertInvoked();
    }
}