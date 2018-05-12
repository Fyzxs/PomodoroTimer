namespace PomodoroTimerLib.Library.Timers
{
    /*
     * A COMMENT! *GASP!*
     * I had this as a Bool, because it resolves to boolean. But it's not a bool. It's a slug.
     * It needs to resolve to a bool for the bookend, but not a bool.
     * To resolve via the implicit cast can't be an interface... so... no interface.
     */
    internal sealed class TimerAutoReset
    {

        public static readonly TimerAutoReset Repeat = new TimerAutoReset(true);
        public static readonly TimerAutoReset Single = new TimerAutoReset(false);

        public static implicit operator bool(TimerAutoReset origin) => origin._value;

        private readonly bool _value;

        private TimerAutoReset(bool value) => _value = value;
    }
}