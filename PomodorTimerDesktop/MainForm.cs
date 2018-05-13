using PomodoroTimerLib.Library.Counters;
using PomodoroTimerLib.Library.Primitives.Texts;
using PomodoroTimerLib.Library.Time.Interval;
using PomodoroTimerLib.Library.Timers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PomodorTimerDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnStartSession_Click(object sender, EventArgs e)
        {
            //CountDownTimer countDownTimer = new CountDownTimer(new Minutes(24), new Milliseconds(500));
            CountdownTimer countdownTimer = new CountdownTimer(new Seconds(2), new Milliseconds(500));
            countdownTimer.RepeatSpecified += CountDownTimerOnRepeatSpecified;
            countdownTimer.Start();
        }

        private void CountDownTimerOnRepeatSpecified(ICountdownTime countDownTime, TimerProgress isMore)
        {
            if (!isMore)
            {
                lblCountDown.Invoke((MethodInvoker)delegate
                {
                    lblCountDown.ForeColor = Color.Red;
                    MessageBox.Show(new Form { TopMost = true }, "Session Timer Up!");
                    this.TopLevel = true;

                });
            }

            lblCountDown.Invoke((MethodInvoker)delegate
            {
                lblCountDown.Text = countDownTime.Remaining().Format(new TextOf(@"mm\:ss"));
            });
        }
    }
}
