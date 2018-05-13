namespace PomodoroTimerLib.Library.Timers {
    public sealed class TimerProgress
    {
        public static readonly TimerProgress More = new TimerProgress();
        public static readonly TimerProgress Last = new TimerProgress();

        public static implicit operator bool(TimerProgress origin) => origin == More;

        private TimerProgress() { }

    }
}