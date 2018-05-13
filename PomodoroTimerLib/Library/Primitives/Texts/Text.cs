namespace PomodoroTimerLib.Library.Primitives.Texts {
    public abstract class Text
    {
        public static implicit operator string(Text origin) => origin.Value();

        protected abstract string Value();
    }
}