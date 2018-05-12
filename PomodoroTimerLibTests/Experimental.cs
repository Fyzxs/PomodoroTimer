using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using System.Threading;

namespace PomodoroTimerLibTests
{
    [TestClass]
    public class Experimental
    {
        [TestMethod, TestCategory("experimental")]
        public void TimerThatInvokesUpdateMethodEverySecond()
        {
            /*
                Create a timer for N period, invokes an update every second with remaining time
            */

            CountdownEvent latch = new CountdownEvent(10);

            ITimer timerBookEnd = new RepeatingTimer(new Milliseconds(500));
            timerBookEnd.Elapsed += () => latch.Signal();
            timerBookEnd.Start();
            latch.Wait(11 * 1000).Should().BeTrue();
        }

        [TestMethod, TestCategory("experimental")]
        public void GetsTimeLeft()
        {
            /*
                Create a timer for N period, invokes an update every second with remaining time
            */

            CountdownEvent latch = new CountdownEvent(31);

            IRepeatSpecifiedTimesTimer timer = new RepeatSpecifiedTimesTimer(new Seconds(15), new Milliseconds(500));
            timer.RepeatSpecified += (duration, elapsed, more) =>
            {

                latch.Signal();
            };

            timer.Start();
            latch.Wait(16 * 1000).Should().BeTrue();

        }

    }
}
