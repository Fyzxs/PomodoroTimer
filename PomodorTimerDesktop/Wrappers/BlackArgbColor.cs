using System.Drawing;

namespace PomodorTimerDesktop.Wrappers {
    public sealed class BlackArgbColor : ArgbColor
    {
        protected override Color Value() => Color.Black;
    }
}