using PomodorTimerDesktop.Wrappers;

namespace PomodoroTimerDesktopTests.Mocks {
    public partial class MockEnabled : IEnabled {
        private MockMethod _enable;
        private MockMethod _disable;
        private MockEnabled() { }
        public void Enable() => _enable.Invoke();
        public void Disable() => _disable.Invoke();

        public class Builder {
            private readonly MockMethod _enable = new MockMethod("MockEnabled#Enable");
            private readonly MockMethod _disable = new MockMethod("MockEnabled#Disable");

            public MockEnabled Build()
            {
                return new MockEnabled
                {
                    _enable = _enable,
                    _disable = _disable
                };
            }

            public Builder Enable()
            {
                _enable.UpdateInvocation();
                return this;
            }

            public Builder Enable(params Action[] actions)
            {
                _enable.UpdateInvocation(actions);
                return this;
            }

            public Builder Disable()
            {
                _disable.UpdateInvocation();
                return this;
            }

            public Builder Disable(params Action[] actions)
            {
                _disable.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertEnableInvoked() => _enable.AssertInvoked();
        public void AssertDisableInvoked() => _disable.AssertInvoked();
    }
}