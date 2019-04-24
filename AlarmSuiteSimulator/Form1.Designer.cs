namespace AlarmSuiteSimulator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.startBtn = new System.Windows.Forms.Button();
            this.helloWorldLabel = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.timeBar = new System.Windows.Forms.TrackBar();
            this.timeIntLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.elapsedLbl = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.maxLbl = new System.Windows.Forms.Label();
            this.maxBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.timeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBar)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(85, 160);
            this.startBtn.Margin = new System.Windows.Forms.Padding(2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(97, 28);
            this.startBtn.TabIndex = 2;
            this.startBtn.Text = "Start Sim";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // helloWorldLabel
            // 
            this.helloWorldLabel.AutoSize = true;
            this.helloWorldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helloWorldLabel.Location = new System.Drawing.Point(202, 19);
            this.helloWorldLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.helloWorldLabel.Name = "helloWorldLabel";
            this.helloWorldLabel.Size = new System.Drawing.Size(105, 26);
            this.helloWorldLabel.TabIndex = 3;
            this.helloWorldLabel.Text = "Simulator";
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(207, 160);
            this.stopBtn.Margin = new System.Windows.Forms.Padding(2);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(97, 28);
            this.stopBtn.TabIndex = 5;
            this.stopBtn.Text = "Stop Sim";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(322, 160);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(97, 28);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Reset Alarms";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // timeBar
            // 
            this.timeBar.Location = new System.Drawing.Point(141, 88);
            this.timeBar.Minimum = 3;
            this.timeBar.Name = "timeBar";
            this.timeBar.Size = new System.Drawing.Size(104, 45);
            this.timeBar.TabIndex = 12;
            this.timeBar.Value = 3;
            this.timeBar.Scroll += new System.EventHandler(this.timeBar_Scroll);
            // 
            // timeIntLbl
            // 
            this.timeIntLbl.AutoSize = true;
            this.timeIntLbl.Location = new System.Drawing.Point(145, 69);
            this.timeIntLbl.Name = "timeIntLbl";
            this.timeIntLbl.Size = new System.Drawing.Size(68, 13);
            this.timeIntLbl.TabIndex = 13;
            this.timeIntLbl.Text = "Time Interval";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // elapsedLbl
            // 
            this.elapsedLbl.AutoSize = true;
            this.elapsedLbl.Location = new System.Drawing.Point(211, 136);
            this.elapsedLbl.Name = "elapsedLbl";
            this.elapsedLbl.Size = new System.Drawing.Size(126, 13);
            this.elapsedLbl.TabIndex = 14;
            this.elapsedLbl.Text = "Time Elapsed: 0 seconds";
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // maxLbl
            // 
            this.maxLbl.AutoSize = true;
            this.maxLbl.Location = new System.Drawing.Point(290, 69);
            this.maxLbl.Name = "maxLbl";
            this.maxLbl.Size = new System.Drawing.Size(61, 13);
            this.maxLbl.TabIndex = 16;
            this.maxLbl.Text = "Max Alarms";
            // 
            // maxBar
            // 
            this.maxBar.Location = new System.Drawing.Point(286, 88);
            this.maxBar.Maximum = 5;
            this.maxBar.Minimum = 1;
            this.maxBar.Name = "maxBar";
            this.maxBar.Size = new System.Drawing.Size(104, 45);
            this.maxBar.TabIndex = 15;
            this.maxBar.Value = 1;
            this.maxBar.Scroll += new System.EventHandler(this.maxBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.maxLbl);
            this.Controls.Add(this.maxBar);
            this.Controls.Add(this.elapsedLbl);
            this.Controls.Add(this.timeIntLbl);
            this.Controls.Add(this.timeBar);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.helloWorldLabel);
            this.Controls.Add(this.startBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Alarm Suite Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TrackBar timeBar;
        private System.Windows.Forms.Label timeIntLbl;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label elapsedLbl;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label maxLbl;
        private System.Windows.Forms.TrackBar maxBar;
    }
}

