using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers;
using System;
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

            ITimer timerBookEnd = new RepeatingEventTimer(new Milliseconds(500));
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

            ITimeLeftTimer timerBookEnd = new TimeLeftTimer(new Seconds(15));
            timerBookEnd.Elapsed += () =>
            {
                latch.Signal();
                Console.WriteLine("Remaining:: " + latch.CurrentCount);
            };
            timerBookEnd.TimeLeft += end =>
            {
                latch.Signal();
                //TODO: probaly need a "format" method to get this kinda form
                Console.WriteLine(((TimeSpan)end).ToString(@"mm\:ss"));
                Console.WriteLine("Remaining: " + latch.CurrentCount);
            };
            timerBookEnd.Start();
            latch.Wait(16 * 1000).Should().BeTrue();

        }

    }
}
