using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace HospitalManagementSystem
{
    public partial class appoinForm : Form
    {
        int seri = 0;
        string doc_ID = "";
        string appt = "";
       static DateTime tday= DateTime.Now;
        static string today = tday.ToString();
        int i;
        public appoinForm()
        {
            InitializeComponent();
            //var id64Generator = new Id64Generator(10);
            //  textBox3.Text= Guid.NewGuid().ToString().Substring(0, 4);
            Random random = new Random();
             i = random.Next();
        }

       
       string doc_serial="";
        private bool button2WasClicked = false;
        private void appoinForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult confirm = MessageBox.Show("Confirm to close???", "Exit", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else if (confirm == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientPage slip = new PatientPage();
            slip.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (button2WasClicked == true)
            {


                MessageBox.Show(" Print");




            }
            else
            {
                MessageBox.Show("Send to compounder before Print");
            }
        }

   


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void appoinForm_Load(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
         

            string query = "SELECT * FROM DOCTOR_DATA ";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();

            try
            {

                while (myReader.Read())
                {

                    comboBox2.Items.Add(myReader.GetString(myReader.GetOrdinal("department")));
                    appt= myReader["doc_visit_lim"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int hello = Convert.ToInt32(appt);
            string start = "6:00 AM";
            DateTime start1 = Convert.ToDateTime(start);
            string start2 = "7:00 AM";
            DateTime start22 = Convert.ToDateTime(start2);
            if (start1 < tday&& tday < start22 )
            {
                string rev = "30";

                OracleCommand thisCommand4 = sv.thisConnection.CreateCommand();

                thisCommand4.CommandText =
                    "update DOCTOR_DATA set doc_visit_lim ='" + rev + "'";

                thisCommand4.Connection = sv.thisConnection;
                thisCommand4.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {
                    thisCommand4.ExecuteNonQuery();
                
                    this.Hide();
                }
                catch (Exception dx)
                {
                    Console.WriteLine(dx.Message);
                }

            }

            sv.thisConnection.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            if (seri >= 0)
            {
                seri = seri - 1;
                OracleCommand thisCommand3 = CN.thisConnection.CreateCommand();

                thisCommand3.CommandText =
                    "update DOCTOR_DATA set doc_visit_lim ='" + seri + "' where DOC_ID= '" + doc_ID + "'";

                thisCommand3.Connection = CN.thisConnection;
                thisCommand3.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {
                    thisCommand3.ExecuteNonQuery();
                  //  MessageBox.Show("Updated");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
        
            button2WasClicked = true;
            connection sv = new connection();
            sv.thisConnection.Open();
            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM doctor_appointment", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "doctor_appointment");

            DataRow thisRow = thisDataSet.Tables["doctor_appointment"].NewRow();
            try
            {

                thisRow["patient_name"] = textBox1.Text;
                thisRow["token_id"] = textBox3.Text;
                thisRow["p_age"] = textBox2.Text;
                thisRow["mobile"] = textBox6.Text;
                thisRow["req_date"] = dateTimePicker1.Value.ToString();
                thisRow["doc_name"] = comboBox1.Text;
                thisRow["department"] = comboBox2.Text;
                thisRow["visit_status"] = "no comp";


                    thisDataSet.Tables["doctor_appointment"].Rows.Add(thisRow);



                int a = thisAdapter.Update(thisDataSet, "doctor_appointment");

                if (a == 1)
                    MessageBox.Show("Successful");
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                    seri = seri + 1;
                    OracleCommand thisCommand4 = CN.thisConnection.CreateCommand();

                    thisCommand4.CommandText =
                        "update DOCTOR_DATA set doc_visit_lim ='" + seri + "' where DOC_ID= '" + doc_ID + "'";

                    thisCommand4.Connection = CN.thisConnection;
                    thisCommand4.CommandType = CommandType.Text;
                    //For Insert Data Into Oracle//
                    try
                    {
                        thisCommand4.ExecuteNonQuery();
                        //  MessageBox.Show("Updated");
                        this.Hide();
                    }
                    catch (Exception dx)
                    {
                        Console.WriteLine(dx.Message);
                    }
                }

            sv.thisConnection.Close();
                PatientPage ob = new PatientPage();
                ob.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Doctor visit Limit out!!!!");
            }
         
        }


        private void comboBox1_DataSourceChanged(object sender, EventArgs e)
        {

        }
//'dependent comboboxList
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        string    val= comboBox2.Text.ToString();

            connection sv = new connection();
            sv.thisConnection.Open();
            string query = "SELECT * FROM doctor_data WHERE department = '" + val + "'";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();

            try
            {

                while (myReader.Read())
                {

                    comboBox1.Items.Add(myReader.GetString(myReader.GetOrdinal("doc_name")));
                    

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

            sv.thisConnection.Close();


           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string doc_n = comboBox1.Text.ToString();
            connection sv = new connection();
            sv.thisConnection.Open();
            OracleCommand doc_pro = sv.thisConnection.CreateCommand();

            textBox5.Text = "";
            doc_pro.CommandText =
        "SELECT * FROM doctor_data where doc_name= '" + doc_n + "'";

            OracleDataReader thisReader4 = doc_pro.ExecuteReader();


            while (thisReader4.Read())
            {
                try
                {

                    textBox5.Text = thisReader4["appointment_time"].ToString();
                    OracleCommand thisCommand = sv.thisConnection.CreateCommand();
                    textBox3.Text = "";
                    thisCommand.CommandText =
                    "SELECT * FROM doctor_data where department= '" + comboBox2.Text + "' and doc_name='" + comboBox1.Text + "'";

                    OracleDataReader thisReader = thisCommand.ExecuteReader();

                    while (thisReader.Read())
                    {
                        try
                        {
                            int limit = Convert.ToInt32(thisReader["doc_visit_lim"].ToString());
                           
                            if (limit>=1) {
                                String dy = tday.Day.ToString();
                                String mn = tday.Month.ToString();
                                String yy = tday.Year.ToString();
                                textBox3.Text = dy+mn+yy + thisReader["doc_id"].ToString() + (31-limit);
                            }
                            seri = limit;
                            doc_ID = thisReader["doc_id"].ToString();
                        }
                        catch
                        { MessageBox.Show("Failure"); }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            sv.thisConnection.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

