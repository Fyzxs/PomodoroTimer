using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Interval;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class TimeIntervalToTextTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldReturnTimeIntervalAsText()
        {
            //Arrange
            TimeInterval interval = new Seconds(60 * 10 + 12);
            Text format = new TextOf(@"mm\:ss");
            TimeIntervalToText subject = new TimeIntervalToText(interval, format);

            //Act
            string actual = subject;

            //Assert
            actual.Should().Be("10:12");
        }
    }
}