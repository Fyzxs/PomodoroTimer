namespace PomodoroTimerLib.Library.Primitives.Bools
{
    internal sealed class BoolOf : Bool
    {
        private readonly bool _origin;

        public BoolOf(bool origin) => _origin = origin;

        protected override bool Value() => _origin;
    }
}