namespace PomodoroTimerLib.Library.Primitives.Numbers {
    public sealed class NumberOf : Number
    {
        private readonly double _origin;

        public NumberOf(double origin) => _origin = origin;

        protected override double Value() => _origin;
    }
}