using PomodoroTimerLib.Library.Primitives.Texts;
using PomodorTimerDesktop.Periods;
using PomodorTimerDesktop.Wrappers;
using System;
using System.Windows.Forms;

namespace PomodorTimerDesktop
{
    //TODO: Add label with which timer is running
    public partial class MainForm : Form, IMainForm
    {
        private readonly IPomodoroPeriod _session;

        private readonly IPomodoroPeriod _shortBreak;

        private readonly IPomodoroPeriod _longBreak;

        public MainForm() : this(new SessionPomodoroPeriod(), new ShortBreakPomodoroPeriod(), new LongBreakPomodoroPeriod())
        { }

        private MainForm(IPomodoroPeriod session, IPomodoroPeriod shortBreak, IPomodoroPeriod longBreak)
        {
            _session = session;
            _shortBreak = shortBreak;
            _longBreak = longBreak;

            _session.SetMainForm(this);
            _shortBreak.SetMainForm(this);
            _longBreak.SetMainForm(this);

            InitializeComponent();
        }

        public IVisibility SessionStartVisibility() => new VisibilityOf(btnStartSession);

        public IVisibility ShortBreakStartVisibility() => new VisibilityOf(btnStartShortBreak);

        public IVisibility LongBreakStartVisibility() => new VisibilityOf(btnStartLongBreak);

        public IEnabled SessionStartEnabled() => new EnabledOf(btnStartSession);

        public IEnabled ShortBreakStartEnabled() => new EnabledOf(btnStartShortBreak);

        public IEnabled LongBreakStartEnabled() => new EnabledOf(btnStartLongBreak);

        public IWriteText CountDownTextWriter() => new WriteControl(lblCountDown);

        public IWriteColor CountDownForeColorWriter() => new ForeColorWriter(lblCountDown);

        public void ShowAlert(Text message) => Invoke((MethodInvoker)delegate//TODO: Asymmetric Fix to MessageBox
        {
            MessageBox.Show(new Form { TopMost = true }, message);
        });

        public void ToTop() => Invoke((MethodInvoker)BringToFront);

        private void btnStartSession_Click(object sender, EventArgs e) => _session.Start();

        private void btnStartShortBreak_Click(object sender, EventArgs e) => _shortBreak.Start();

        private void btnStartLongBreak_Click(object sender, EventArgs e) => _longBreak.Start();
    }

    public interface IMainForm
    {
        IVisibility SessionStartVisibility();
        IVisibility ShortBreakStartVisibility();
        IVisibility LongBreakStartVisibility();
        IEnabled SessionStartEnabled();
        IEnabled ShortBreakStartEnabled();
        IEnabled LongBreakStartEnabled();
        IWriteText CountDownTextWriter();
        IWriteColor CountDownForeColorWriter();
        void ShowAlert(Text message);
        void ToTop();
    }
}