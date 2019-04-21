using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AlarmSuiteSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stopBtn.Enabled = false;
            servRateLbl.Text = "Service Rate: " + servBar.Value + " seconds";
            trigRateLbl.Text = "Trigger Rate: " + trigBar.Value + " seconds";
            alertRateLbl.Text = "Alert Rate: " + alertBar.Value + " seconds";
            timeIntLbl.Text = "Time Interval: " + timeBar.Value + " seconds";
        }

        private void startBtn_Click(object sender, EventArgs e)
        {         
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            resetBtn.Enabled = false;
            timer1.Interval = timeBar.Value * 1000;
            timer1.Start();

        }
        
        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
            resetBtn.Enabled = true;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            //Reset alarms to "ok" status
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int servRate = servBar.Value;
            int trigRate = trigBar.Value;
            int alertRate = alertBar.Value;


        }

        private void servBar_Scroll(object sender, EventArgs e)
        {
            servRateLbl.Text = "Service Rate: " + servBar.Value + " seconds";
        }

        private void trigBar_Scroll(object sender, EventArgs e)
        {
            trigRateLbl.Text = "Trigger Rate: " + trigBar.Value + " seconds";
        }

        private void alertBar_Scroll(object sender, EventArgs e)
        {
            alertRateLbl.Text = "Alert Rate: " + alertBar.Value + " seconds";
        }

        private void timeBar_Scroll(object sender, EventArgs e)
        {
            timeIntLbl.Text = "Time Interval: " + timeBar.Value + " seconds";
        }
    }
}
