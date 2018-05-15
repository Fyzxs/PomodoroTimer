using System.Windows.Forms;

namespace PomodorTimerDesktop.Wrappers
{
    internal sealed class ForeColorWriter : IWriteColor
    {
        private readonly Control _control;

        public ForeColorWriter(Control control) => _control = control;

        public void Write(ArgbColor item) => _control.Invoke((MethodInvoker)delegate
        {
            _control.ForeColor = item;
        });
    }
    public interface IWriteColor
    {
        void Write(ArgbColor item);
    }
}