using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLib.Library.Timers
{
    /*
     * A COMMENT! *GASP!*
     * I had this as a Bool, because it resolves to boolean. But it's not a bool. It's a slug.
     * It needs to resolve to a bool for the bookend, but not a bool conceptually.
     * To resolve via the implicit cast can't be an interface... so... no interface.
     */
    public sealed class TimerProgress
    {
        public static readonly TimerProgress More = new TimerProgress();
        public static readonly TimerProgress Last = new TimerProgress();

        public Bool AsBool() => new BoolOf(this == More);

        private TimerProgress() { }
    }
}