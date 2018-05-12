using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLib.Library.Primitives {
    internal sealed class NumberLessThan : Bool
    {
        private readonly Number _lhs;
        private readonly Number _rhs;

        public NumberLessThan(Number lhs, Number rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }

        protected override bool Value() => (int)_lhs < _rhs;
    }
}