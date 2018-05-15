using System.Drawing;

namespace PomodorTimerDesktop.Wrappers {
    internal sealed class RedArgbColor : ArgbColor
    {
        protected override Color Value() => Color.Red;
    }
}