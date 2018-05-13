namespace PomodoroTimerLib.Library.Primitives.Texts {
    public sealed class TextOf : Text
    {
        private readonly string _origin;
        public TextOf(string origin) => _origin = origin;
        protected override string Value() => _origin;
    }
}