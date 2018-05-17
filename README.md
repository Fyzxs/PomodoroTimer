# PomodoroTimer
A MicroObject Pomodoro Timer

# How To Use
From the Code: Run "PomodoroTimerDesktop" Project

# InterfaceMocks
This is a framework for fakes in unit tests. It's been pulled in from github.com/fyzxs/IMock repository. It's a Mock/Fake framework that evolved out of using MicroObjects. 

# ConsolePomodoro
This is my initial experimentation platform. It doesn't do the full thing.

# PomodoroTimerLib
This is intended to hold the core functionality of running the timers. Allowing a thin UI on top to work in multiple environments. 
Theory is good...
Currently the implementation in PomodoroTimerDesktop has some tight coupling. That will need to be worked out before the dream can happen.


# PomodoroTimerDesktop
This is the primary application for the pomodor timer.
While the timer lengths are currently hard coded, code is setup to be quickly modifiable for other mechanisms.
The Session is set to 25 minutes as that's what multple teams have found works best. Some like a little longer, but over all; it's solid.
The Short break is 7 minutes. While a bit long for a lot of pomodoro - again, the teams have found this number works well for them. 
Just enough time to get away, and not feel rushed back. Smokers tend to go a little long anyway.
The long break is 15 minutes. We've found that much longer we start to lose the groove. Much shorter and it's not long compared to our normal short break.

These clearly don't add nicely up to an hour - It's what works for the team. The goal of the timer is to increase team productivity, what the team favors matters.
