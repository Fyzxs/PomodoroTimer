namespace PomodoroTimerLibTests.Library.Time.Interval
{
    public sealed class FromSeconds : Milliseconds
    {
        private readonly double _seconds;
        public FromSeconds(double seconds) => _seconds = seconds;
        protected override double Value() => _seconds * 1000D;
    }
}