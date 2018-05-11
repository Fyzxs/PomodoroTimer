using PomodoroTimerLib.Library.Primitives;

namespace PomodoroTimerLib.Library.Timers
{
    public sealed class TimerAutoReset : Bool
    {
        public static readonly TimerAutoReset Repeat = new TimerAutoReset(true);
        public static readonly TimerAutoReset Single = new TimerAutoReset(false);
        private readonly bool _value;

        private TimerAutoReset(bool value) => _value = value;
        protected override bool Value() => _value;
    }
}