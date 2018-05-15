using InterfaceMocks;
using PomodorTimerDesktop.Wrappers;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockVisibility : IVisibility
    {
        private MockMethod _show;
        private MockMethod _hide;
        private MockVisibility() { }
        public void Show() => _show.Invoke();
        public void Hide() => _hide.Invoke();

        public class Builder
        {
            private readonly MockMethod _show = new MockMethod("MockVisibility#Show");
            private readonly MockMethod _hide = new MockMethod("MockVisibility#Hide");

            public MockVisibility Build()
            {
                return new MockVisibility
                {
                    _show = _show,
                    _hide = _hide
                };
            }

            public Builder Show()
            {
                _show.UpdateInvocation();
                return this;
            }

            public Builder Show(params Action[] actions)
            {
                _show.UpdateInvocation(actions);
                return this;
            }

            public Builder Hide()
            {
                _hide.UpdateInvocation();
                return this;
            }

            public Builder Hide(params Action[] actions)
            {
                _hide.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertShowInvoked() => _show.AssertInvoked();
        public void AssertHideInvoked() => _hide.AssertInvoked();
    }
}