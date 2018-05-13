using System;
using PomodoroTimerLib.Library.Primitives.Texts;

namespace PomodoroTimerLib.Library.Time.Interval {
    internal sealed class TimeIntervalToText : Text
    {
        private readonly TimeInterval _timeInterval;
        private readonly Text _format;

        public TimeIntervalToText(TimeInterval timeInterval, Text format)
        {
            _timeInterval = timeInterval;
            _format = format;
        }

        protected override string Value() => ((TimeSpan)_timeInterval).ToString(_format);
    }
}