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
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }
        string text;

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
           
            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM HOSPITAL_LOGIN", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "HOSPITAL_LOGIN");

            DataRow thisRow = thisDataSet.Tables["HOSPITAL_LOGIN"].NewRow();
            OracleCommand thisCommand = sv.thisConnection.CreateCommand();
            thisCommand.CommandText =
            "SELECT * FROM HOSPITAL_LOGIN WHERE username='" + textBox1.Text + "'";
            
            
          
            OracleDataReader thisReader = thisCommand.ExecuteReader();

           


            try
            {

                if(thisReader.Read()) {
                    MessageBox.Show("Username already exists!!!");
                }
                else
                {
                    thisRow["username"] = textBox1.Text;
                    thisRow["password"] = textBox2.Text;

                    thisRow["designation"] = thisReader["designation"].ToString();
                    thisDataSet.Tables["HOSPITAL_LOGIN"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "HOSPITAL_LOGIN");
                MessageBox.Show("Submitted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            Welcome ob = new Welcome();
            ob.Show();
            this.Hide();
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome ob = new Welcome();
            ob.Show();
            this.Hide();
        }

        private void Add_FormClosing(object sender, FormClosingEventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          

    

        }
    }
}
