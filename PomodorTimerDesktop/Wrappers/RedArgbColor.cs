using System.Drawing;

namespace PomodorTimerDesktop.Wrappers {
    public sealed class RedArgbColor : ArgbColor
    {
        protected override Color Value() => Color.Red;
    }
}