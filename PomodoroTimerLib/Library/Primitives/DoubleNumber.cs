namespace PomodoroTimerLib.Library.Primitives {
    public abstract class DoubleNumber
    {
        public static implicit operator double(DoubleNumber origin) => origin.Value();
        protected abstract double Value();
    }
}