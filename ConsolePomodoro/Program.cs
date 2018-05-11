﻿using PomodoroTimerLib.Library.Time;
using PomodoroTimerLib.Library.Timers;
using System;
using System.Threading;

namespace ConsolePomodoro
{
    internal class Program
    {
        private static readonly ManualResetEvent WaitHandle = new ManualResetEvent(false);
        private static void Main(string[] args)
        {
            // Start a thread or two to do some work...
            ThreadPool.QueueUserWorkItem(o => BackgroundWork(WaitHandle));

            // Block until our ManualResetEvent is set
            WaitHandle.WaitOne();

            Console.Clear();
            Console.WriteLine("Timer Over!");
            Console.WriteLine("Enter to Exit");
            Console.ReadLine();
        }

        private static void BackgroundWork(EventWaitHandle waitHandle)
        {
            RunSession();
        }

        private static void RunBreak()
        {
            Console.Clear();
            Console.WriteLine("Take a break!");
            Console.WriteLine("Hit Enter to start your break:");
            Console.ReadLine();
            TimeLeftTimer timer = new TimeLeftTimer(new Seconds(2));
            timer.TimeLeft += end => PrintRemainingBreak(end);
            timer.Elapsed += () =>
            {
                timer.Close();
                WaitHandle.Set();
            };
            timer.Start();
        }

        private static void RunSession()
        {
            Console.Clear();
            Console.WriteLine("Time for Pomodoro!");
            Console.WriteLine("Hit Enter to start your session:");
            Console.ReadLine();
            TimeLeftTimer timer = new TimeLeftTimer(new Seconds(2));
            timer.TimeLeft += end => PrintRemainingSession(end);
            timer.Elapsed += () =>
            {
                timer.Close();
                RunBreak();
            };
            timer.Start();
        }

        private static void PrintRemainingSession(TimeSpan timespan)
        {
            ConsoleColor prevFore = Console.ForegroundColor;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("################################################################################");
            Console.WriteLine("#####                    Quinn Gil's Pomodoro Session                      #####");
            Console.WriteLine("################################################################################");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(timespan.ToString(@"mm\:ss"));
            Console.ForegroundColor = prevFore;
        }

        private static void PrintRemainingBreak(TimeSpan timespan)
        {
            ConsoleColor prevFore = Console.ForegroundColor;
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("################################################################################");
            Console.WriteLine("#####                     Quinn Gil's Pomodoro Break                       #####");
            Console.WriteLine("################################################################################");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(timespan.ToString(@"mm\:ss"));
            Console.ForegroundColor = prevFore;
        }
    }

    public sealed class Pomodoro
    {
        private readonly EventWaitHandle _waitHandle;

        public Pomodoro(EventWaitHandle waitHandle) => _waitHandle = waitHandle;

        private void ExitApplication() => _waitHandle.Set();
    }
}
