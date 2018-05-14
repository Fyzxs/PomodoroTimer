using System.Drawing;

namespace PomodorTimerDesktop.Wrappers {
    public abstract class ArgbColor
    {
        public static implicit operator Color(ArgbColor origin) => origin.Value();

        protected abstract Color Value();

        public void Into(IWriteColor item) => item.Write(this);
    }
}