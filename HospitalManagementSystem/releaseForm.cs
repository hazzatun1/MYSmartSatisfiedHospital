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
    public partial class releaseForm : Form
    {
        public releaseForm()
        {
            InitializeComponent();
        }
        public string tday= "";
      public string wardNo = "";
     public string bedFree = "";
        public string rel_date = "";
        public string bf="";
        private void p_id_TextChanged(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand2 = CN.thisConnection.CreateCommand();
            textBox1.Text = "";
            thisCommand2.CommandText =
            "SELECT p_id FROM patient_data";
            OracleDataReader thisReader2 = thisCommand2.ExecuteReader();

                if (p_id.Text == ""&& thisReader2.Read().ToString() != p_id.Text)
            {
                td.Text = "";
                bc.Text = "";
                fc.Text = "";
                mc.Text = "";
                sc.Text = "";
                textBox1.Text = "";
            }

            else {
                
                    OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            textBox1.Text = "";
            thisCommand.CommandText =
            "SELECT * FROM patient_data where p_id= '" + p_id.Text + "'";
            OracleDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read())
            {

                try
                {
                    // string filePath = thisReader["picture"].ToString();
                    // this.pb_profilepics.Image = Image.FromFile(filePath);
                      //   string ad_cost = thisReader["admit_cost"].ToString();
                int per_day_bed_cost = 5000;
                int per_day_food_cost = 500;
                int per_day_med_cost = 3000;
                int per_day_ser_cost = 1000;
                string fromDate = thisReader["admit_date"].ToString();
                 wardNo = thisReader["ward_no"].ToString();
                DateTime enteredDate = DateTime.Parse(fromDate);
                DateTime today = DateTime.Today;
                tday = today.ToString();
                int totalDay = (today.Date - enteredDate.Date).Days;
                td.Text = totalDay.ToString();
                bc.Text = per_day_bed_cost.ToString();
                fc.Text = per_day_food_cost.ToString();
                mc.Text = per_day_med_cost.ToString();
                sc.Text = per_day_ser_cost.ToString();
                int totalCost = (per_day_bed_cost * totalDay)+ (per_day_food_cost * totalDay)+ (per_day_med_cost * totalDay)+ (per_day_ser_cost * totalDay);
                rel_date= thisReader["release_date"].ToString();
                textBox1.Text = totalCost.ToString();
              
                }
                catch
                { MessageBox.Show("Failure"); }


            }


            
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yes = "Yes";
            connection sv = new connection();
            sv.thisConnection.Open();
            if (rel_date == "0")
            {
                OracleCommand thisCommand4 = sv.thisConnection.CreateCommand();
                thisCommand4.CommandText =
    "update patient_data set release_date ='" + tday + "',if_release_paid ='" + yes + "'," +
    "rel_amount='" + textBox1.Text + "' where p_id= '" + p_id.Text + "'";

                thisCommand4.Connection = sv.thisConnection;
                thisCommand4.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {
                    thisCommand4.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                OracleCommand thisCommand2 = sv.thisConnection.CreateCommand();
                //  textBox1.Text = "";
                thisCommand2.CommandText =
                "SELECT * FROM ward_allocation where ward_no= '" + wardNo + "'";

                OracleDataReader thisReader2 = thisCommand2.ExecuteReader();

                while (thisReader2.Read())
                {

                    //   string ad_cost = thisReader["admit_cost"].ToString();
                    string tb = thisReader2["total_bed"].ToString();
                    int totalbed = Convert.ToInt32(tb);
                    bf = thisReader2["bed_free"].ToString();
                    int bedFre = Convert.ToInt32(bf);
                    if (bedFre <= totalbed) {
                        int bed = (bedFre + 1);
                        bedFree = bed.ToString();

                    }
                    else if (bedFre > totalbed)
                    {
                        bedFree = tb;
                    }

                    try
                    {
                        // string filePath = thisReader["picture"].ToString();
                        // this.pb_profilepics.Image = Image.FromFile(filePath);
                    }
                    catch
                    { MessageBox.Show("Failure"); }


                }


                OracleCommand thisCommand3 = sv.thisConnection.CreateCommand();

                thisCommand3.CommandText =
                    "update ward_allocation set bed_free ='" + bedFree + "' where ward_no= '" + wardNo + "'";

                thisCommand3.Connection = sv.thisConnection;
                thisCommand3.CommandType = CommandType.Text;
                //For Insert Data Into Oracle//
                try
                {

                    thisCommand3.ExecuteNonQuery();
                    MessageBox.Show("released");

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            


            if (bf != "0")
            {
                OracleCommand thisCommand5 = sv.thisConnection.CreateCommand();
                thisCommand5.CommandText =
        "update ward_allocation set  empty_ward = ward_no where ward_no= '" + wardNo + "'";

                OracleDataReader thisReader4 = thisCommand5.ExecuteReader();
            }

            else if (bf == "0")
            {
                OracleCommand thisCommand6 = sv.thisConnection.CreateCommand();
                thisCommand6.CommandText =
        "update ward_allocation set  empty_ward = 0 where ward_no= '" + wardNo + "'";

                OracleDataReader thisReader7 = thisCommand6.ExecuteReader();
            }

        }
            else
            {
                MessageBox.Show("Have been released");
            }


            sv.thisConnection.Close();

            PatientPage ob = new PatientPage();
            ob.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientPage ob = new PatientPage();
            ob.Show();
            this.Hide();
        }

        private void releaseForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
