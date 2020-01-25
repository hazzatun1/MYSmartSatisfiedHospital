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
    public partial class AccountHome : Form
    {
        OracleDataReader thisReader;
        public AccountHome()
        {
            InitializeComponent();
        }

        private void AccountHome_Load(object sender, EventArgs e)
        {

        }






        private void button1_Click_1(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();
            OracleCommand thisCommand = new OracleCommand();
            thisCommand.Connection = CN.thisConnection;
            thisCommand.CommandText = "SELECT * FROM HOSPITAL_LOGIN WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
            thisReader = thisCommand.ExecuteReader();
            if (thisReader.Read())
            {
                AccountPage oform = new AccountPage();
                oform.Show();
                this.Hide();

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HomePage oform = new HomePage();
            oform.Show();
            this.Hide();
        }
    }
}
