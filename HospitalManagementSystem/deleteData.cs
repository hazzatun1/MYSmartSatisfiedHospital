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
    public partial class deleteData : Form
    {
        public deleteData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void deleteData_FormClosing(object sender, FormClosingEventArgs e)
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
            connection con = new connection();
            con.thisConnection.Open();

            OracleCommand thisCommand1 = con.thisConnection.CreateCommand();

            thisCommand1.CommandText =
                "delete hospital_login where id= '" + em_id.Text + "'";

            thisCommand1.Connection = con.thisConnection;
            thisCommand1.CommandType = CommandType.Text;

            OracleCommand thisCommand2 = con.thisConnection.CreateCommand();

            thisCommand2.CommandText =
                "delete salary_account where id= '" + em_id.Text + "'";

            thisCommand2.Connection = con.thisConnection;
            thisCommand2.CommandType = CommandType.Text;

            OracleCommand thisCommand3 = con.thisConnection.CreateCommand();

            thisCommand3.CommandText =
                "delete doctor_data where doc_id= '" + em_id.Text + "'";

            thisCommand3.Connection = con.thisConnection;
            thisCommand3.CommandType = CommandType.Text;
            //For Insert Data Into Oracle//
            try
            {
                thisCommand1.ExecuteNonQuery();
                thisCommand2.ExecuteNonQuery();
                thisCommand3.ExecuteNonQuery();
                MessageBox.Show("delete successfully");
                this.Hide();
                deleteData ob = new deleteData();
                ob.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void deleteData_Load(object sender, EventArgs e)
        {
          
        }

        private void em_id_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand1 = CN.thisConnection.CreateCommand();

            thisCommand1.CommandText =
               "SELECT * FROM hospital_login where id= '" + em_id.Text + "'";

            OracleDataReader thisReader1 = thisCommand1.ExecuteReader();
            OracleCommand thisCommand2 = CN.thisConnection.CreateCommand();

            thisCommand2.CommandText =
                 "SELECT * FROM salary_account where id= '" + em_id.Text + "'";

            OracleDataReader thisReader2 = thisCommand2.ExecuteReader();
            OracleCommand thisCommand3 = CN.thisConnection.CreateCommand();

            thisCommand3.CommandText =
                "SELECT * FROM doctor_data where doc_id= '" + em_id.Text + "'";

            OracleDataReader thisReader3 = thisCommand3.ExecuteReader();

            
                    while (thisReader3.Read() && thisReader1.Read() && thisReader2.Read())
                    {
                        ListViewItem lsvItem1 = new ListViewItem();
                       
                        lsvItem1.SubItems.Add(thisReader3["ward_no"].ToString());
                        lsvItem1.SubItems.Add(thisReader3["department"].ToString());
                        lsvItem1.SubItems.Add(thisReader3["appointment_time"].ToString());
                        lsvItem1.SubItems.Add(thisReader3["designation"].ToString());
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader2["name"].ToString();
                lsvItem.SubItems.Add(thisReader1["username"].ToString());
                lsvItem.SubItems.Add(thisReader2["position"].ToString());
                lsvItem.SubItems.Add(thisReader2["salary"].ToString());
                lsvItem.SubItems.Add(thisReader2["duty_time"].ToString());
                lsvItem.SubItems.Add(thisReader2["join_date"].ToString());
            


                listView1.Items.Add(lsvItem);
                listView2.Items.Add(lsvItem1);
                    }
            while (thisReader1.Read() && thisReader2.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader2["name"].ToString();
                lsvItem.SubItems.Add(thisReader1["username"].ToString());
                lsvItem.SubItems.Add(thisReader2["position"].ToString());
                lsvItem.SubItems.Add(thisReader2["salary"].ToString());
                lsvItem.SubItems.Add(thisReader2["duty_time"].ToString());
                lsvItem.SubItems.Add(thisReader2["join_date"].ToString());
                listView1.Items.Add(lsvItem);
            }

            CN.thisConnection.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            AdminPage ob = new AdminPage();
            ob.Show();
            this.Hide();
        }
    }
}
