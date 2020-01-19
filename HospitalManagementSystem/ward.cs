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
    public partial class ward : Form
       
    {
        public ward()
        {
            InitializeComponent();
        }
        int result=0;
        string res = "";
        private void ward_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
     "SELECT * FROM ward_allocation";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["ward_no"].ToString();
                lsvItem.SubItems.Add(thisReader["total_bed"].ToString());

                lsvItem.SubItems.Add(thisReader["bed_free"].ToString());

                lsvItem.SubItems.Add(thisReader["empty_ward"].ToString());
                



                listView1.Items.Add(lsvItem);
            }


            CN.thisConnection.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdminPage ob = new AdminPage();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM ward_allocation", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "ward_allocation");

            DataRow thisRow = thisDataSet.Tables["ward_allocation"].NewRow();
            try
            {

              
                thisRow["ward_no"] = textBox1.Text;
                thisRow["total_bed"] = "0";
                thisRow["bed_free"] = "0";
                thisRow["empty_ward"] = "0";

                thisDataSet.Tables["ward_allocation"].Rows.Add(thisRow);

                    thisAdapter.Update(thisDataSet, "ward_allocation");
                    MessageBox.Show("Submitted");
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
            this.Hide();
            ward ss = new ward();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleCommand thisCommand = sv.thisConnection.CreateCommand();
            thisCommand.CommandText =
           "SELECT * FROM ward_allocation where ward_no= '" + textBox3.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read() )
            {

                string cmd1 = thisReader["total_bed"].ToString();
                int cc = Convert.ToInt32(cmd1);
                string cmd2 = thisReader["bed_free"].ToString();
                int cc2 = Convert.ToInt32(cmd2);
                int text = Convert.ToInt32(textBox2.Text);
                result = (text - cc) + cc2;
                res = result.ToString();
                if (cc2!=0 || Convert.ToInt32(textBox3.Text) !=0)
                {

                    thisCommand.CommandText =
            "update ward_allocation set  empty_ward = ward_no where ward_no= '" + textBox3.Text + "'";

                    OracleDataReader thisReader2 = thisCommand.ExecuteReader();
                }

                    try
                {
                    // string filePath = thisReader["picture"].ToString();
                    // this.pb_profilepics.Image = Image.FromFile(filePath);
                }
                catch
                { MessageBox.Show("Failure"); }


            }


            // OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "update ward_allocation set  Total_bed = '" + textBox2.Text + "', " +
                "bed_free='" + res + "' where ward_no= '" + textBox3.Text + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;

            //For Insert Data Into Oracle//
            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
           

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


    
            sv.thisConnection.Close();
            this.Hide();
            ward ob = new ward();
            ob.Show();
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

         
        }

        private void ward_FormClosing(object sender, FormClosingEventArgs e)
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
