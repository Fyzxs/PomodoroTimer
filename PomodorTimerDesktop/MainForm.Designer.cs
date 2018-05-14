namespace PomodorTimerDesktop
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartSession = new System.Windows.Forms.Button();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.btnStartShortBreak = new System.Windows.Forms.Button();
            this.btnStartLongBreak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStartSession
            // 
            this.btnStartSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartSession.Location = new System.Drawing.Point(170, 6);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(184, 72);
            this.btnStartSession.TabIndex = 0;
            this.btnStartSession.Text = "Start\r\nSession";
            this.btnStartSession.UseVisualStyleBackColor = true;
            this.btnStartSession.Click += new System.EventHandler(this.btnStartSession_Click);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 128F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(7, 84);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(510, 193);
            this.lblCountDown.TabIndex = 1;
            this.lblCountDown.Text = "00:00";
            // 
            // btnStartShortBreak
            // 
            this.btnStartShortBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartShortBreak.Location = new System.Drawing.Point(170, 6);
            this.btnStartShortBreak.Name = "btnStartShortBreak";
            this.btnStartShortBreak.Size = new System.Drawing.Size(184, 72);
            this.btnStartShortBreak.TabIndex = 2;
            this.btnStartShortBreak.Text = "Start\r\nShort Break";
            this.btnStartShortBreak.UseVisualStyleBackColor = true;
            this.btnStartShortBreak.Visible = false;
            this.btnStartShortBreak.Click += new System.EventHandler(this.btnStartShortBreak_Click);
            // 
            // btnStartLongBreak
            // 
            this.btnStartLongBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartLongBreak.Location = new System.Drawing.Point(170, 6);
            this.btnStartLongBreak.Name = "btnStartLongBreak";
            this.btnStartLongBreak.Size = new System.Drawing.Size(184, 72);
            this.btnStartLongBreak.TabIndex = 3;
            this.btnStartLongBreak.Text = "Start\r\nLong Break";
            this.btnStartLongBreak.UseVisualStyleBackColor = true;
            this.btnStartLongBreak.Visible = false;
            this.btnStartLongBreak.Click += new System.EventHandler(this.btnStartLongBreak_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 293);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.btnStartSession);
            this.Controls.Add(this.btnStartLongBreak);
            this.Controls.Add(this.btnStartShortBreak);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quinn Gil\'s Pomodoro Desktop App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSession;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Button btnStartShortBreak;
        private System.Windows.Forms.Button btnStartLongBreak;
    }
}

