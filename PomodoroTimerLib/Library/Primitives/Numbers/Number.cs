using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLib.Library.Primitives.Numbers
{
    public abstract class Number
    {
        public static implicit operator double(Number origin) => origin.Value();
        protected abstract double Value();

        public Bool LessThan(Number other) => new NumberLessThan(this, other);

        public Bool EqualTo(Number other) => new NumbersEqual(this, other);
    }
}