using System;
using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLib.Library.Primitives.Numbers
{
    internal sealed class NumbersEqual : Bool
    {
        private readonly Number _lhs;
        private readonly Number _rhs;
        private const double Tolerance = 0.0001;

        public NumbersEqual(Number lhs, Number rhs)
        {
            _lhs = lhs;
            _rhs = rhs;
        }
        protected override bool Value() => Math.Abs(_lhs - _rhs) < Tolerance;
    }
}