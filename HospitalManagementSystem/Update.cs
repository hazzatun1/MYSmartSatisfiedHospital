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
    public partial class Update : Form
    {
        string un = "";
        public Update()
        {
            InitializeComponent();
        }
        public Update(string text)
        {
            InitializeComponent();
            un = text;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "update HOSPITAL_LOGIN set username ='" + textBox1.Text +"', password = '" + textBox2.Text + 
                "' where username= '" + un + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;
            //For Insert Data Into Oracle//
            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("Updated");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            sv.thisConnection.Close();

            Welcome ob = new Welcome(textBox1.Text);
            ob.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome ob = new Welcome();
            ob.Show();
            this.Hide();
        }

        private void Update_FormClosing(object sender, FormClosingEventArgs e)
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
