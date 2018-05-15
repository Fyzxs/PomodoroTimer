using System.Drawing;

namespace PomodorTimerDesktop.Wrappers {
    internal sealed class BlackArgbColor : ArgbColor
    {
        protected override Color Value() => Color.Black;
    }
}