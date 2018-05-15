using InterfaceMocks;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodorTimerDesktop;
using PomodorTimerDesktop.Wrappers;
using System;

namespace PomodoroTimerDesktopTests.Mocks
{
    public partial class MockMainForm : IMainForm
    {
        private MockMethodWithResponse<IVisibility> _sessionStartVisibility;
        private MockMethodWithResponse<IVisibility> _shortBreakStartVisibility;
        private MockMethodWithResponse<IVisibility> _longBreakStartVisibility;
        private MockMethodWithResponse<IEnabled> _sessionStartEnable;
        private MockMethodWithResponse<IEnabled> _shortBreakStartEnabled;
        private MockMethodWithResponse<IEnabled> _longBreakStartEnabled;
        private MockMethodWithResponse<IWriteText> _countDownTextWriter;
        private MockMethodWithResponse<IWriteColor> _countDownForeColorWriter;
        private MockMethodWithParam<Text> _showAlert;
        private MockMethod _toTop;
        private MockMainForm() { }
        public IVisibility SessionStartVisibility() => _sessionStartVisibility.Invoke();
        public IVisibility ShortBreakStartVisibility() => _shortBreakStartVisibility.Invoke();
        public IVisibility LongBreakStartVisibility() => _longBreakStartVisibility.Invoke();
        public IEnabled SessionStartEnable() => _sessionStartEnable.Invoke();
        public IEnabled ShortBreakStartEnabled() => _shortBreakStartEnabled.Invoke();
        public IEnabled LongBreakStartEnabled() => _longBreakStartEnabled.Invoke();
        public IWriteText CountDownTextWriter() => _countDownTextWriter.Invoke();
        public IWriteColor CountDownForeColorWriter() => _countDownForeColorWriter.Invoke();
        public void ShowAlert(Text message) => _showAlert.Invoke(message);
        public void ToTop() => _toTop.Invoke();

        public class Builder
        {
            private readonly MockMethodWithResponse<IVisibility> _sessionStartVisibility = new MockMethodWithResponse<IVisibility>("MockMainForm#SessionStartVisibility");
            private readonly MockMethodWithResponse<IVisibility> _shortBreakStartVisibility = new MockMethodWithResponse<IVisibility>("MockMainForm#ShortBreakStartVisibility");
            private readonly MockMethodWithResponse<IVisibility> _longBreakStartVisibility = new MockMethodWithResponse<IVisibility>("MockMainForm#LongBreakStartVisibility");
            private readonly MockMethodWithResponse<IEnabled> _sessionStartEnable = new MockMethodWithResponse<IEnabled>("MockMainForm#SessionStartEnable");
            private readonly MockMethodWithResponse<IEnabled> _shortBreakStartEnabled = new MockMethodWithResponse<IEnabled>("MockMainForm#ShortBreakStartEnabled");
            private readonly MockMethodWithResponse<IEnabled> _longBreakStartEnabled = new MockMethodWithResponse<IEnabled>("MockMainForm#LongBreakStartEnabled");
            private readonly MockMethodWithResponse<IWriteText> _countDownTextWriter = new MockMethodWithResponse<IWriteText>("MockMainForm#CountDownTextWriter");
            private readonly MockMethodWithResponse<IWriteColor> _countDownForeColorWriter = new MockMethodWithResponse<IWriteColor>("MockMainForm#CountDownForeColorWriter");
            private readonly MockMethodWithParam<Text> _showAlert = new MockMethodWithParam<Text>("MockMainForm#ShowAlert");
            private readonly MockMethod _toTop = new MockMethod("MockMainForm#ToTop");

            public MockMainForm Build()
            {
                return new MockMainForm
                {
                    _sessionStartVisibility = _sessionStartVisibility,
                    _shortBreakStartVisibility = _shortBreakStartVisibility,
                    _longBreakStartVisibility = _longBreakStartVisibility,
                    _sessionStartEnable = _sessionStartEnable,
                    _shortBreakStartEnabled = _shortBreakStartEnabled,
                    _longBreakStartEnabled = _longBreakStartEnabled,
                    _countDownTextWriter = _countDownTextWriter,
                    _countDownForeColorWriter = _countDownForeColorWriter,
                    _showAlert = _showAlert,
                    _toTop = _toTop
                };
            }

            public Builder SessionStartVisibility(params IVisibility[] responseValues)
            {
                _sessionStartVisibility.UpdateInvocation(responseValues);
                return this;
            }

            public Builder SessionStartVisibility(params Func<IVisibility>[] responseValues)
            {
                _sessionStartVisibility.UpdateInvocation(responseValues);
                return this;
            }

            public Builder ShortBreakStartVisibility(params IVisibility[] responseValues)
            {
                _shortBreakStartVisibility.UpdateInvocation(responseValues);
                return this;
            }

            public Builder ShortBreakStartVisibility(params Func<IVisibility>[] responseValues)
            {
                _shortBreakStartVisibility.UpdateInvocation(responseValues);
                return this;
            }

            public Builder LongBreakStartVisibility(params IVisibility[] responseValues)
            {
                _longBreakStartVisibility.UpdateInvocation(responseValues);
                return this;
            }

            public Builder LongBreakStartVisibility(params Func<IVisibility>[] responseValues)
            {
                _longBreakStartVisibility.UpdateInvocation(responseValues);
                return this;
            }

            public Builder SessionStartEnable(params IEnabled[] responseValues)
            {
                _sessionStartEnable.UpdateInvocation(responseValues);
                return this;
            }

            public Builder SessionStartEnable(params Func<IEnabled>[] responseValues)
            {
                _sessionStartEnable.UpdateInvocation(responseValues);
                return this;
            }

            public Builder ShortBreakStartEnabled(params IEnabled[] responseValues)
            {
                _shortBreakStartEnabled.UpdateInvocation(responseValues);
                return this;
            }

            public Builder ShortBreakStartEnabled(params Func<IEnabled>[] responseValues)
            {
                _shortBreakStartEnabled.UpdateInvocation(responseValues);
                return this;
            }

            public Builder LongBreakStartEnabled(params IEnabled[] responseValues)
            {
                _longBreakStartEnabled.UpdateInvocation(responseValues);
                return this;
            }

            public Builder LongBreakStartEnabled(params Func<IEnabled>[] responseValues)
            {
                _longBreakStartEnabled.UpdateInvocation(responseValues);
                return this;
            }

            public Builder CountDownTextWriter(params IWriteText[] responseValues)
            {
                _countDownTextWriter.UpdateInvocation(responseValues);
                return this;
            }

            public Builder CountDownTextWriter(params Func<IWriteText>[] responseValues)
            {
                _countDownTextWriter.UpdateInvocation(responseValues);
                return this;
            }

            public Builder CountDownForeColorWriter(params IWriteColor[] responseValues)
            {
                _countDownForeColorWriter.UpdateInvocation(responseValues);
                return this;
            }

            public Builder CountDownForeColorWriter(params Func<IWriteColor>[] responseValues)
            {
                _countDownForeColorWriter.UpdateInvocation(responseValues);
                return this;
            }

            public Builder ShowAlert()
            {
                _showAlert.UpdateInvocation();
                return this;
            }

            public Builder ShowAlert(params Action[] actions)
            {
                _showAlert.UpdateInvocation(actions);
                return this;
            }

            public Builder ToTop()
            {
                _toTop.UpdateInvocation();
                return this;
            }

            public Builder ToTop(params Action[] actions)
            {
                _toTop.UpdateInvocation(actions);
                return this;
            }
        }

        public void AssertSessionStartVisibilityInvoked() => _sessionStartVisibility.AssertInvoked();
        public void AssertShortBreakStartVisibilityInvoked() => _shortBreakStartVisibility.AssertInvoked();
        public void AssertLongBreakStartVisibilityInvoked() => _longBreakStartVisibility.AssertInvoked();
        public void AssertSessionStartEnableInvoked() => _sessionStartEnable.AssertInvoked();
        public void AssertShortBreakStartEnabledInvoked() => _shortBreakStartEnabled.AssertInvoked();
        public void AssertLongBreakStartEnabledInvoked() => _longBreakStartEnabled.AssertInvoked();
        public void AssertCountDownTextWriterInvoked() => _countDownTextWriter.AssertInvoked();
        public void AssertCountDownForeColorWriterInvoked() => _countDownForeColorWriter.AssertInvoked();
        public void AssertShowAlertInvokedWith(Text message) => _showAlert.AssertInvokedWith(message);
        public void AssertToTopInvoked() => _toTop.AssertInvoked();
    }
}