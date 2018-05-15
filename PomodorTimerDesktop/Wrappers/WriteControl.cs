using System.Windows.Forms;
using PomodoroTimerLib.Library.Primitives.Texts;

namespace PomodorTimerDesktop.Wrappers {
    internal sealed class WriteControl : IWriteText
    {
        private readonly Control _control;

        public WriteControl(Control control) => _control = control;

        public void Write(Text item) => _control.Invoke((MethodInvoker)delegate
        {
            _control.Text = item;
        });
    }
}