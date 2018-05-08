namespace PomodoroTimerLibTests.Library.Time
{
    //Remove in favor of TimeInterval and DoubleNumber
    public abstract class Milliseconds
    {
        public static implicit operator double(Milliseconds origin) => origin.Value();
        protected abstract double Value();
    }
}