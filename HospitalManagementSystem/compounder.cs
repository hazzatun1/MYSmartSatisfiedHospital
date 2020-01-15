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
    public partial class compounder : Form
    {
        public compounder()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
        }

        private void compounder_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
          
            thisCommand.CommandText =
    "SELECT * FROM doctor_appointment where weight_kg IS NULL and bp is null and pulse_min is null";
       
            OracleDataReader thisReader = thisCommand.ExecuteReader();
         

            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["token_id"].ToString();

                listView1.Items.Add(lsvItem);
            }

        
            CN.thisConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();



            OracleCommand thisCommand = sv.thisConnection.CreateCommand();
            string no = "No";
            thisCommand.CommandText =
                "update doctor_appointment set weight_kg = '" + wet.Text + "',pulse_min = '" + pulse.Text + "',"+
                "bp = '" + bpp.Text + "',additional_info = '" + add.Text + "', visit_status = '" + no + "' where token_id= '" + token.Text + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;
            //For Insert Data Into Oracle//
            try
            {
                thisCommand.ExecuteNonQuery();
                MessageBox.Show("submitted");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }





            sv.thisConnection.Close();
            this.Hide();
            compounder ob = new compounder();
            ob.Show();
          
        }

        private void compounder_FormClosing(object sender, FormClosingEventArgs e)
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
