﻿namespace PomodorTimerDesktop
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
            this.SuspendLayout();
            // 
            // btnStartSession
            // 
            this.btnStartSession.Location = new System.Drawing.Point(12, 12);
            this.btnStartSession.Name = "btnStartSession";
            this.btnStartSession.Size = new System.Drawing.Size(181, 72);
            this.btnStartSession.TabIndex = 0;
            this.btnStartSession.Text = "Start Session";
            this.btnStartSession.UseVisualStyleBackColor = true;
            this.btnStartSession.Click += new System.EventHandler(this.btnStartSession_Click);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountDown.Location = new System.Drawing.Point(41, 87);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(130, 51);
            this.lblCountDown.TabIndex = 1;
            this.lblCountDown.Text = "00:00";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.btnStartSession);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quinn Gil\'s Pomodoro Desktop App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartSession;
        private System.Windows.Forms.Label lblCountDown;
    }
}
