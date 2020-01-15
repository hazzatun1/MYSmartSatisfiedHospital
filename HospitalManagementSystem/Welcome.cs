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
    public partial class Welcome : Form
    {
        string dd = "";
        public Welcome()
        {
            InitializeComponent();

        }
        public Welcome(string a)
        {
            InitializeComponent();
            dd = a;
        }


        private void Welcome_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM HOSPITAL_LOGIN where username='" + dd + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["username"].ToString();
               // lsvItem.SubItems.Add(thisReader["password"].ToString());
                lsvItem.SubItems.Add(thisReader["designation"].ToString());





                listView1.Items.Add(lsvItem);
            }


            CN.thisConnection.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Update oform = new Update(dd);
            oform.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection con = new connection();
            con.thisConnection.Open();

            OracleCommand thisCommand1 = con.thisConnection.CreateCommand();

            thisCommand1.CommandText =
                "delete HOSPITAL_LOGIN where username= '" + dd + "'";

            thisCommand1.Connection = con.thisConnection;
            thisCommand1.CommandType = CommandType.Text;
            //For Insert Data Into Oracle//
            try
            {
                thisCommand1.ExecuteNonQuery();
                MessageBox.Show("delete successfully");
                this.Hide();
                Welcome ob = new Welcome();
                ob.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Add oform = new Add();
            oform.Show();
            this.Hide();
        }
       

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 oform = new Form1();
            this.Hide();
            oform.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }


    }
    

