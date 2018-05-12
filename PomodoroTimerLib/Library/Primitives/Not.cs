namespace PomodoroTimerLib.Library.Primitives
{
    internal sealed class Not : Bool
    {
        private readonly Bool _origin;

        public Not(Bool origin) => _origin = origin;

        protected override bool Value() => !_origin;
    }
}