using PomodoroTimerLib.Library.Primitives;
using PomodoroTimerLib.Library.Primitives.Bools;

namespace PomodoroTimerLib.Library
{
    public sealed class CountdownState : ICountdownState
    {
        private readonly Number _events;
        private readonly ICounter _counter;
        public CountdownState(Number events, ICounter counter)
        {
            _events = events;
            _counter = counter;
        }
        public Bool Finished() => _events.LessThan(_counter.Value());

        public Bool Last() => _counter.Value().EqualTo(_events);
    }

    public interface ICountdownState
    {
        Bool Finished();
        Bool Last();
    }
}