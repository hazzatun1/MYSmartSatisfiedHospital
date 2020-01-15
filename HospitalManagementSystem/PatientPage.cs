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
    public partial class PatientPage : Form
    {
        int per_day_cost = 0;
        public PatientPage()
        {
            InitializeComponent();
        }
        public PatientPage(int cost)
        {
            InitializeComponent();
            this.per_day_cost = cost;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            appoinForm slip = new appoinForm();
            slip.Show();
            this.Hide();
        }

        private void PatientPage_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdmitForm ob = new AdmitForm();
            ob.Show();
            this.Hide();
        }

        private void PatientPage_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            OracleCommand thisCommand2 = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
    "SELECT * FROM patient_data";
            thisCommand2.CommandText =
   "SELECT * FROM ward_allocation";
            OracleDataReader thisReader = thisCommand.ExecuteReader();
            OracleDataReader thisReader2 = thisCommand2.ExecuteReader();

            while (thisReader.Read() )
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["p_id"].ToString();
                lsvItem.SubItems.Add(thisReader["p_name"].ToString());

                lsvItem.SubItems.Add(thisReader["admit_date"].ToString());

                lsvItem.SubItems.Add(thisReader["release_date"].ToString());
                lsvItem.SubItems.Add(thisReader["ward_no"].ToString());

               //     lsvItem.SubItems.Add(thisReader2["empty_ward"].ToString());


                listView1.Items.Add(lsvItem);
            }

            while (thisReader2.Read())
            {
                ListViewItem lsvItem2 = new ListViewItem();
                lsvItem2.Text = thisReader2["EMPTY_WARD"].ToString();
                listView2.Items.Add(lsvItem2);
            }
            CN.thisConnection.Close();
        }

        private void release_p_Click(object sender, EventArgs e)
        {
            releaseForm ob = new releaseForm();
            ob.Show();
            this.Hide();
        }
    }
}
