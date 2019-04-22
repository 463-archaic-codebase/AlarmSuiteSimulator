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
            this.servBar = new System.Windows.Forms.TrackBar();
            this.stopBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.trigBar = new System.Windows.Forms.TrackBar();
            this.alertBar = new System.Windows.Forms.TrackBar();
            this.servRateLbl = new System.Windows.Forms.Label();
            this.trigRateLbl = new System.Windows.Forms.Label();
            this.alertRateLbl = new System.Windows.Forms.Label();
            this.timeBar = new System.Windows.Forms.TrackBar();
            this.timeIntLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.servBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trigBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(85, 211);
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
            // servBar
            // 
            this.servBar.Location = new System.Drawing.Point(54, 77);
            this.servBar.Minimum = 1;
            this.servBar.Name = "servBar";
            this.servBar.Size = new System.Drawing.Size(104, 45);
            this.servBar.TabIndex = 4;
            this.servBar.Value = 3;
            this.servBar.Scroll += new System.EventHandler(this.servBar_Scroll);
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(207, 211);
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
            this.resetBtn.Location = new System.Drawing.Point(322, 211);
            this.resetBtn.Margin = new System.Windows.Forms.Padding(2);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(97, 28);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Reset Alarms";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // trigBar
            // 
            this.trigBar.Location = new System.Drawing.Point(200, 77);
            this.trigBar.Minimum = 1;
            this.trigBar.Name = "trigBar";
            this.trigBar.Size = new System.Drawing.Size(104, 45);
            this.trigBar.TabIndex = 7;
            this.trigBar.Value = 3;
            this.trigBar.Scroll += new System.EventHandler(this.trigBar_Scroll);
            // 
            // alertBar
            // 
            this.alertBar.Location = new System.Drawing.Point(357, 77);
            this.alertBar.Minimum = 1;
            this.alertBar.Name = "alertBar";
            this.alertBar.Size = new System.Drawing.Size(104, 45);
            this.alertBar.TabIndex = 8;
            this.alertBar.Value = 3;
            this.alertBar.Scroll += new System.EventHandler(this.alertBar_Scroll);
            // 
            // servRateLbl
            // 
            this.servRateLbl.AutoSize = true;
            this.servRateLbl.Location = new System.Drawing.Point(58, 61);
            this.servRateLbl.Name = "servRateLbl";
            this.servRateLbl.Size = new System.Drawing.Size(69, 13);
            this.servRateLbl.TabIndex = 9;
            this.servRateLbl.Text = "Service Rate";
            // 
            // trigRateLbl
            // 
            this.trigRateLbl.AutoSize = true;
            this.trigRateLbl.Location = new System.Drawing.Point(204, 61);
            this.trigRateLbl.Name = "trigRateLbl";
            this.trigRateLbl.Size = new System.Drawing.Size(78, 13);
            this.trigRateLbl.TabIndex = 10;
            this.trigRateLbl.Text = "Triggered Rate";
            // 
            // alertRateLbl
            // 
            this.alertRateLbl.AutoSize = true;
            this.alertRateLbl.Location = new System.Drawing.Point(354, 61);
            this.alertRateLbl.Name = "alertRateLbl";
            this.alertRateLbl.Size = new System.Drawing.Size(54, 13);
            this.alertRateLbl.TabIndex = 11;
            this.alertRateLbl.Text = "Alert Rate";
            // 
            // timeBar
            // 
            this.timeBar.Location = new System.Drawing.Point(200, 144);
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
            this.timeIntLbl.Location = new System.Drawing.Point(204, 125);
            this.timeIntLbl.Name = "timeIntLbl";
            this.timeIntLbl.Size = new System.Drawing.Size(68, 13);
            this.timeIntLbl.TabIndex = 13;
            this.timeIntLbl.Text = "Time Interval";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.timeIntLbl);
            this.Controls.Add(this.timeBar);
            this.Controls.Add(this.alertRateLbl);
            this.Controls.Add(this.trigRateLbl);
            this.Controls.Add(this.servRateLbl);
            this.Controls.Add(this.alertBar);
            this.Controls.Add(this.trigBar);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.servBar);
            this.Controls.Add(this.helloWorldLabel);
            this.Controls.Add(this.startBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Alarm Suite Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.servBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trigBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Label helloWorldLabel;
        private System.Windows.Forms.TrackBar servBar;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.TrackBar trigBar;
        private System.Windows.Forms.TrackBar alertBar;
        private System.Windows.Forms.Label servRateLbl;
        private System.Windows.Forms.Label trigRateLbl;
        private System.Windows.Forms.Label alertRateLbl;
        private System.Windows.Forms.TrackBar timeBar;
        private System.Windows.Forms.Label timeIntLbl;
        private System.Windows.Forms.Timer timer1;
    }
}

