using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using PomodorTimerDesktop.Actions.TimerStart;
using PomodorTimerDesktop.Actions.TimerUpdate;
using PomodorTimerDesktop.Actions.TimerUpdate.Session;
using PomodorTimerDesktop.Actions.TimerUpdate.ShortBreak;
using PomodorTimerDesktop.Wrappers;
using System;
using System.Windows.Forms;

namespace PomodorTimerDesktop
{
    //TODO: Add label with which timer is running
    public partial class MainForm : Form, IMainForm
    {//TODO: See if the related bits can be extracted "SessionStuff", "ShortBreakStuff", "LongBreakStuff"

        private readonly CountdownTimer _sessionTimer;
        private readonly ICountdownTimerStartAction _sessionTimerStart;
        private readonly ICountdownTimerUpdateAction _sessionUpdate;

        private readonly CountdownTimer _shortBreakTimer;
        private readonly ICountdownTimerStartAction _shortBreakTimerStart;
        private readonly ICountdownTimerUpdateAction _shortBreakUpdate;

        private readonly CountdownTimer _longBreakTimer;
        private readonly ICountdownTimerStartAction _longBreakTimerStart;
        private readonly ICountdownTimerUpdateAction _longBreakUpdate;

        public MainForm() : this(
            new CountdownTimer(new Seconds(6), new Milliseconds(500)), new SessionTimerStartAction(), new SessionTimerUpdateAction(),
            new CountdownTimer(new Seconds(3), new Milliseconds(500)), new ShortBreakTimerStartAction(), new ShortBreakTimerUpdateAction(),
            new CountdownTimer(new Seconds(5), new Milliseconds(500)), new LongBreakTimerStartAction(), new ShortBreakTimerUpdateAction())
        { }
        private MainForm(CountdownTimer sessionTimer, ICountdownTimerStartAction sessionTimerStart, ICountdownTimerUpdateAction sessionUpdate,
            CountdownTimer shortBreakTimer, ICountdownTimerStartAction shortBreakTimerStart, ICountdownTimerUpdateAction shortBreakUpdate,
            CountdownTimer longBreakTimer, ICountdownTimerStartAction longBreakTimerStart, ICountdownTimerUpdateAction longBreakUpdate)
        {
            _sessionTimer = sessionTimer;
            _sessionTimerStart = sessionTimerStart;
            _sessionUpdate = sessionUpdate;

            _shortBreakTimer = shortBreakTimer;
            _shortBreakTimerStart = shortBreakTimerStart;
            _shortBreakUpdate = shortBreakUpdate;

            _longBreakTimer = longBreakTimer;
            _longBreakTimerStart = longBreakTimerStart;
            _longBreakUpdate = longBreakUpdate;

            _sessionTimer.RepeatSpecified += SessionTimerOnRepeatSpecified;
            _shortBreakTimer.RepeatSpecified += ShortBreakTimerOnRepeatSpecified;
            _longBreakTimer.RepeatSpecified += LongBreakTimerOnRepeatSpecified;

            InitializeComponent();
        }
        private void btnStartSession_Click(object sender, EventArgs e) => _sessionTimerStart.Act(this, _sessionTimer);
        private void SessionTimerOnRepeatSpecified(ICountdownTime countdownTime, TimerProgress more) => _sessionUpdate.Act(this, countdownTime, more);


        private void btnStartShortBreak_Click(object sender, EventArgs e) => _shortBreakTimerStart.Act(this, _shortBreakTimer);
        private void ShortBreakTimerOnRepeatSpecified(ICountdownTime countdownTime, TimerProgress more) => _shortBreakUpdate.Act(this, countdownTime, more);


        private void btnStartLongBreak_Click(object sender, EventArgs e) => _longBreakTimerStart.Act(this, _longBreakTimer);


        private void LongBreakTimerOnRepeatSpecified(ICountdownTime countdownTime, TimerProgress more)
        {

        }

        public IVisibility SessionStartVisibility() => new VisibilityOf(btnStartSession);

        public IVisibility ShortBreakStartVisibility() => new VisibilityOf(btnStartShortBreak);
        public IVisibility LongBreakStartVisibility() => new VisibilityOf(btnStartLongBreak);

        public IWriteText CountDownTextWriter() => new WriteControl(lblCountDown);

        public IWriteColor CountDownForeColorWriter() => new ForeColorWriter(lblCountDown);

        public void ShowAlert(Text message) => Invoke((MethodInvoker)delegate//TODO: Asymmetric Fix to MessageBox
        {
            MessageBox.Show(new Form { TopMost = true }, message);
        });

        public void ToTop() => Invoke((MethodInvoker)BringToFront);
    }

    internal interface IMainForm
    {
        IVisibility SessionStartVisibility();
        IVisibility LongBreakStartVisibility();
        IWriteText CountDownTextWriter();
        IWriteColor CountDownForeColorWriter();
        void ToTop();
        IVisibility ShortBreakStartVisibility();
        void ShowAlert(Text message);
    }
}