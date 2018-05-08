namespace PomodoroTimerLibTests.Library.Timers
{
    public sealed class TimerBookEndAutoReset
    {
        public static readonly TimerBookEndAutoReset Repeat = new TimerBookEndAutoReset(true);
        public static readonly TimerBookEndAutoReset Single = new TimerBookEndAutoReset(false);
        private readonly bool _value;

        private TimerBookEndAutoReset(bool value) => _value = value;
        public static implicit operator bool(TimerBookEndAutoReset origin) => origin._value;
    }
}