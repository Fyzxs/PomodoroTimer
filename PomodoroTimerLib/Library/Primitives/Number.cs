using PomodoroTimerLib.Library.Primitives.Bools;
using PomodoroTimerLib.Library.Timers;

namespace PomodoroTimerLib.Library.Primitives
{
    public abstract class Number
    {
        public static implicit operator double(Number origin) => origin.Value();
        protected abstract double Value();

        public Bool LessThan(Number other) => new NumberLessThan(this, other);
    }
}