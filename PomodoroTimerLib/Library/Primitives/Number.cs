namespace PomodoroTimerLib.Library.Primitives
{
    public abstract class Number
    {
        public static implicit operator double(Number origin) => origin.Value();
        protected abstract double Value();
    }
}