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
using System.Diagnostics;
using System.Timers;

namespace AlarmSuiteSimulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string cstring = "server=alarmsuite.comd7ceadbpe.us-west-2.rds.amazonaws.com;database=AlarmSuite;uid=alarmSystemAdmin;pwd=alarmSystem2019;";
        static Dictionary<int, List<int>> alarms = new Dictionary<int, List<int>>();
        static Dictionary<int, int> floors = new Dictionary<int, int>();
        static Dictionary<int, string> zones = new Dictionary<int, string>();
        static int elapsed = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            stopBtn.Enabled = false;
            timeIntLbl.Text = "Time Interval: " + timeBar.Value + " seconds";
            timer2.Interval = 1000;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(cstring))
                {
                    //floors only
                    var proc = "USP_Get_Select_FloorZones_Sim";
                    MySqlCommand cmd = new MySqlCommand(proc, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach(DataRow row in dt.Rows)
                        {
                            floors.Add(Convert.ToInt32(row["floor"]), Convert.ToInt32(row["zones"]));
                        }
                    }

                    //gets zones
                    proc = "USP_Select_Zones";
                    cmd = new MySqlCommand(proc, conn);
                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            zones.Add(Convert.ToInt32(row["zoneID"]), row["zoneName"].ToString());
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
            elapsed = 0;
            elapsedLbl.Text = "Time Elapsed: " + elapsed + " seconds";
            startBtn.Enabled = false;
            stopBtn.Enabled = true;
            resetBtn.Enabled = false;
            timer1.Interval = timeBar.Value * 1000;           
            timer1.Start();
            timer2.Start();
        }
        
        //Stops the simulator
        private void stopBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            startBtn.Enabled = true;
            stopBtn.Enabled = false;
            resetBtn.Enabled = true;         
        }

        //Resets alarms to "OK" status
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
            resetBtn.Enabled = false;
        }

        //Every tick alarm statuses will be randomized for a random type, floor, zone
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();


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
                            List<int> ids = new List<int>() { Convert.ToInt32(row["alarmTypeID"]), Convert.ToInt32(row["alarmStatusID"]), Convert.ToInt32(row["floorID"]), Convert.ToInt32(row["zoneID"]), Convert.ToInt32(row["roomNumber"]) };
                            alarms.Add(Convert.ToInt32(row["alarmID"]), ids);
                        }
                    }

                    //Gets a random floor
                    int floor = rand.Next(1, floors.Keys.Last() + 1);
                    //Gets a random zone on the random floor
                    int zone = rand.Next(1, floors[floor] + 1);
                    //Gets a random alarm type
                    int alarmType = rand.Next(1, 4);
                    //Sets the amount of alarms to trigger every tick
                    int triggered = rand.Next(0, 6);
                    int i = 0;
                    foreach (KeyValuePair<int, List<int>> kvp in alarms)
                    {
                        if (kvp.Value[0] == alarmType && kvp.Value[1] != 2 && kvp.Value[2] == floor && kvp.Value[3] == zone && i < triggered)
                        {
                            //Updates alarm status(es)
                            conn.Open();
                            proc = "USP_Update_Status_Sim";
                            cmd = new MySqlCommand(proc, conn);
                            cmd.Parameters.AddWithValue("alarm", kvp.Key);
                            cmd.Parameters.AddWithValue("aStatus", 3);
                            cmd.ExecuteNonQuery();
                            conn.Dispose();
                            conn.Close();

                            //Creates the message to be created for the triggered alarm
                            var message = "";
                            if(alarmType == 1)
                            {
                                message = "Security Alarm <span class='triggered'>TRIGGERED</span> at F" + kvp.Value[2] + "-Z" + zones[kvp.Value[3]] + "-R" + kvp.Value[4];
                            }
                            else if(alarmType == 2)
                            {
                                message = "Carbon Monoxide Alarm <span class='triggered'>TRIGGERED</span> at F" + kvp.Value[2] + "-Z" + zones[kvp.Value[3]] + "-R" + kvp.Value[4];
                            }
                            else if(alarmType == 3)
                            {
                                message = "Fire Alarm <span class='triggered'>TRIGGERED</span> at F" + kvp.Value[2] + "-Z" + zones[kvp.Value[3]] + "-R" + kvp.Value[4];
                            }

                            //Inserts the message
                            conn.Open();
                            proc = "USP_Insert_Message_Sim";
                            cmd = new MySqlCommand(proc, conn);
                            cmd.Parameters.AddWithValue("alarm", kvp.Key);
                            cmd.Parameters.AddWithValue("msgDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("msg", message);
                            cmd.ExecuteNonQuery();
                            conn.Dispose();
                            conn.Close();

                            i++;
                        }
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Something went wrong: " + ex);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            elapsed++;
            elapsedLbl.Text = "Time Elapsed: " + elapsed + " seconds";
        }

        private void timeBar_Scroll(object sender, EventArgs e)
        {
            timeIntLbl.Text = "Time Interval: " + timeBar.Value + " seconds";
        }

    }
}
