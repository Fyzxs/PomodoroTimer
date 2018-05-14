using System.Windows.Forms;

namespace PomodorTimerDesktop.Wrappers
{
    public class EnabledOf : IEnabled
    {
        private readonly Control _control;

        public EnabledOf(Control control) => _control = control;

        public void Enable() => _control.Invoke((MethodInvoker)delegate
        {
            _control.Enabled = true;
        });

        public void Disable() => _control.Invoke((MethodInvoker)delegate
        {
            _control.Enabled = false;
        });
    }
    public interface IEnabled
    {
        void Enable();
        void Disable();
    }
}