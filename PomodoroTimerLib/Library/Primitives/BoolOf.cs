namespace PomodoroTimerLib.Library.Primitives {
    public sealed class BoolOf : Bool
    {
        private readonly bool _origin;

        public BoolOf(bool origin) => _origin = origin;

        protected override bool Value() => _origin;
    }
}