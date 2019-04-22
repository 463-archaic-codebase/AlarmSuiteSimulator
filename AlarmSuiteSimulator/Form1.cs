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

        static string cstring = "server=alarmsuite.comd7ceadbpe.us-west-2.rds.amazonaws.com;database=AlarmSuite;uid=alarmSystemAdmin;pwd=alarmSystem2019;";
        static int floors = 0;
        static Dictionary<int, List<int>> alarms = new Dictionary<int, List<int>>();
        static Dictionary<int, string> users = new Dictionary<int, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            stopBtn.Enabled = false;
            servRateLbl.Text = "Service Rate: " + servBar.Value + " seconds";
            trigRateLbl.Text = "Trigger Rate: " + trigBar.Value + " seconds";
            alertRateLbl.Text = "Alert Rate: " + alertBar.Value + " seconds";
            timeIntLbl.Text = "Time Interval: " + timeBar.Value + " seconds";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(cstring))
                {
                    //Gets amount of floors
                    var proc = "USP_Select_Floors";
                    MySqlCommand cmd = new MySqlCommand(proc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach(DataRow row in dt.Rows)
                        {
                            floors++;
                        }
                    }
                    
                    //Get users
                    proc = "USP_Select_Users_Sim";
                    cmd = new MySqlCommand(proc, conn);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            users.Add(Convert.ToInt32(row["userID"]), row["userName"].ToString());
                        }
                    }
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex);
            }
        }

        //Starts the simulator
        private void startBtn_Click(object sender, EventArgs e)
        {         
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            resetBtn.Enabled = false;
            timer1.Interval = timeBar.Value * 1000;
            timer1.Start();
        }
        
        //Stops the simulator
        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
            resetBtn.Enabled = true;
            
        }

        //Resets alarms to "ok" status
        private void resetBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection(cstring);
            try
            {
                cn.Open();
                var proc = "USP_Reset_Alarms";
                MySqlCommand cmd = new MySqlCommand(proc, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cn.Dispose();
                cn.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex);
            }
        }

        //Every tick alarm statuses will be randomized
        private void timer1_Tick(object sender, EventArgs e)
        {
            //int servRate = servBar.Value;
            //int trigRate = trigBar.Value;
            //int alertRate = alertBar.Value;

            Random rand = new Random();
            //int floor = rand.Next(1, floors);

            try
            {
                //Resets alarms dictionary and gets the updated alarms
                alarms.Clear();
                using (MySqlConnection conn = new MySqlConnection(cstring))
                {
                    var proc = "USP_Select_Alarm_Sim";
                    MySqlCommand cmd = new MySqlCommand(proc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        foreach (DataRow row in dt.Rows)
                        {
                            List<int> ids = new List<int>() { Convert.ToInt32(row["alarmTypeID"]), Convert.ToInt32(row["alarmStatusID"]), Convert.ToInt32(row["floorID"]) };
                            alarms.Add(Convert.ToInt32(row["alarmID"]), ids);
                        }
                    }
                }
             
                foreach (KeyValuePair<int, List<int>> kvp in alarms)
                {
                    int alarmType = rand.Next(1, 6);
                    int status = rand.Next(1, 4);

                    if (kvp.Value[0] == alarmType)
                    {
                        if (kvp.Value[2] == status)
                        {
                            //Alarm status is the same, so move on
                            continue;
                        }
                        else
                        {
                            //OK
                            if (status == 1)
                            {

                                //Service -> OK
                                if (kvp.Value[2] == 2)
                                {
                                    //Service performed
                                }
                                //Triggered -> OK
                                else if (kvp.Value[2] == 3)
                                {
                                    //User resolved alarm
                                }
                                //Alert -> OK
                                else if (kvp.Value[2] == 4)
                                {
                                    //Alert resolved
                                }
                            }
                            //Service
                            else if (status == 2)
                            {
                                //OK -> Service
                                if (kvp.Value[2] == 1)
                                {
                                    //General maintenance
                                }
                                //Alert -> Service
                                else if(kvp.Value[2] == 4)
                                {
                                    //Alarm to be serviced
                                }
                            }
                            //Triggered
                            else if (status == 3)
                            {
                                //OK -> Triggered
                                if(kvp.Value[2] == 1)
                                {
                                    //Alarm triggered
                                }
                            }
                            //Alert
                            else
                            {
                                //Triggerd -> Alert
                                if(kvp.Value[2] == 3)
                                {
                                    //User confirmed alert
                                }
                            }
                        }                                             
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex);
            }
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
