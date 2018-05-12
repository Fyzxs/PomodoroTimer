using FluentAssertions;
using InterfaceMocks.Reflection;
using InterfaceMocks.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Time.Instant;
using PomodoroTimerLib.Library.Time.Interval;
using System;

namespace PomodoroTimerLibTests.Library.Time.Interval
{
    [TestClass]
    public class NowAtFirstAccessUntilTests
    {

        [TestMethod, TestCategory("unit")]
        public void ShouldBeNowAtFirstAccessPlusInterval()
        {
            //Arrange
            TimeInstant timeInstant = new Now();
            NowAtFirstAccessUntil subject = new PrivateCtor<NowAtFirstAccessUntil>(timeInstant);

            //Act
            TimeSpan actual = subject;

            //Assert
            actual.Should().BeCloseTo(TimeSpan.Zero, 3);
            actual.Should().BeNegative();
        }

        [TestMethod, TestCategory("functional")]
        public void ShouldValidateTheVariables()
        {
            //Arrange
            ClassVariableTypeValidation classVariableTypeValidation = new ClassVariableTypeValidation()
                .Add<AddTimeIntervalAtFirstAccess>("_timeInstant");

            //Act
            NowAtFirstAccessUntil subject = new NowAtFirstAccessUntil(null);

            //Assert
            classVariableTypeValidation.AssertExpectedVariables(subject);
        }
    }
}