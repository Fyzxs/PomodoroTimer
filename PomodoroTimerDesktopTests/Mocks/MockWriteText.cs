using InterfaceMocks;
using PomodoroTimerLib.Library.Primitives.Texts;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockWriteText : IWriteText
    {
        private MockMethodWithParam<Text> _write;
        private MockWriteText() { }
        public void Write(Text item) => _write.Invoke(item);

        public class Builder
        {
            private readonly MockMethodWithParam<Text> _write = new MockMethodWithParam<Text>("MockWriteText#Write");

            public MockWriteText Build()
            {
                return new MockWriteText { _write = _write };
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

        public void AssertWriteInvokedWith(Text item) => _write.AssertInvokedWith(item);
    }

    public partial class MockWriteText
    {
        public void AssertWriteInvokedWithCustom(Action<Text> assertion) => _write.AssertCustom(assertion);
    }
}