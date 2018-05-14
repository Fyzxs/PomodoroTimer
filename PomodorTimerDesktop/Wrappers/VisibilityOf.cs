﻿using System.Windows.Forms;

namespace PomodorTimerDesktop.Wrappers {
    public sealed class VisibilityOf : IVisibility
    {
        private readonly Control _control;

        public VisibilityOf(Control control) => _control = control;

        public void Show() => _control.Invoke((MethodInvoker)delegate { _control.Visible = true; });
        public void Hide() => _control.Invoke((MethodInvoker)delegate { _control.Visible = false; });
    }
}