namespace PomodoroTimerLib.Library.Primitives {
    public sealed class DoubleNumberOf : DoubleNumber
    {
        private readonly double _origin;

        public DoubleNumberOf(double origin) => _origin = origin;

        protected override double Value() => _origin;
    }
}