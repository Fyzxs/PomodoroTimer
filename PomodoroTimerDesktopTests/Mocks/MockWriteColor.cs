using InterfaceMocks;
using PomodorTimerDesktop.Wrappers;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockWriteColor : IWriteColor
    {
        private MockMethodWithParam<ArgbColor> _write;
        private MockWriteColor() { }
        public void Write(ArgbColor item) => _write.Invoke(item);

        public class Builder
        {
            private readonly MockMethodWithParam<ArgbColor> _write = new MockMethodWithParam<ArgbColor>("MockWriteColor#Write");

            public MockWriteColor Build()
            {
                return new MockWriteColor { _write = _write };
            }

            public Builder Write()
            {
                _write.UpdateInvocation();
                return this;
            }

            public Builder Write(params Action[] actions)
            {
                _write.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertWriteInvokedWith(ArgbColor item) => _write.AssertInvokedWith(item);
    }

    public partial class MockWriteColor
    {
        public void AssertWriteInvokedWithCustom(Action<ArgbColor> assertion) => _write.AssertCustom(assertion);
    }
}