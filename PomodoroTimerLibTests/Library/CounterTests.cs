﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PomodoroTimerLib.Library;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomodoroTimerLibTests.Library
{
    [TestClass]
    public class CounterTests
    {
        [TestMethod, TestCategory("unit")]
        public void ShouldShouldIncrement()
        {
            //Arrange
            Counter subject = new Counter();

            //Act
            subject.Increment();

            //Assert
            double actual = subject.Value();
            actual.Should().Be(1);
        }

        [TestMethod, TestCategory("unit")]
        public void ShouldBeThreadSafe()
        {
            /*
             * NCrunch is a false positive on this test - qgil:20180512
             * Use this class as the example for failure
             *
                public class Counter2 : ICounter
                {
                    private long _count;

                    public Number Value() => new NumberOf(_count);

                    public void Increment() => _count++;
                }
             *
             */

            //Arrange
            Counter subject = new Counter();
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                tasks.Add(Task.Run(() => subject.Increment()));
            }

            //Act
            Task.WaitAll(tasks.ToArray());

            //Assert
            double actual = subject.Value();
            actual.Should().Be(100);
        }

    }
}