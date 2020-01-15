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
    public partial class AdminPage : Form
    {

       // int costpd = 12000;
        public AdminPage()
        {
            InitializeComponent();
        }
       // static DateTime dt = new DateTime(2012, 12, 1, 10, 30, 50);
         static DateTime dt = DateTime.Today;
        static DateTime firstDay = new DateTime(dt.Year, dt.Month, 1);
        bool dayOfFirstDay = Convert.ToBoolean(firstDay.DayOfWeek);
        static DateTime dt6 = firstDay.AddMonths(+1);




        private void AdminPage_Load(object sender, EventArgs e)
        {

            if (dayOfFirstDay)
            {

                textBox1.Text = "Today is Salary";
                textBox1.ReadOnly = true;
            }
            else
            {
                textBox1.Text = dt6.ToString();
                textBox1.ReadOnly = true;
            }

            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            tot_income.Text = "";
            thisCommand.CommandText =
            "SELECT SUM(total_cost) as admit_cost,SUM(rel_amount) as rel_cost FROM patient_data";
            OracleDataReader thisReader = thisCommand.ExecuteReader();



            while (thisReader.Read())
            {

                string ad_cost = thisReader["admit_cost"].ToString();
                int a_cost = Convert.ToInt32(ad_cost);
                string rel_cost = thisReader["rel_cost"].ToString();
                int r_cost = Convert.ToInt32(rel_cost);
                int TotalCost = a_cost + r_cost;
                tot_income.Text = TotalCost.ToString();
                tot_income.ReadOnly = true;
                textBox2.Text = ad_cost;
                textBox3.Text = rel_cost;

                try
                {

                }
                catch
                { MessageBox.Show("Failure"); }


            }

        }
    


        private void AdminPage_FormClosing(object sender, FormClosingEventArgs e)
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
        
        private void button7_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
            
          
        }

        private void Edit_data_Click(object sender, EventArgs e)
        {
            editData ob = new editData();
            ob.Show();
            this.Hide();

        }

        private void DeleteData_Click(object sender, EventArgs e)
        {
            deleteData ob = new deleteData();
            ob.Show();
            this.Hide();
        }

        private void AddData_Click(object sender, EventArgs e)
        {
            addData ob = new addData();
            ob.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ward_Click(object sender, EventArgs e)
        {
            ward ob = new ward();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addData ob = new addData();
            ob.Show();
            this.Hide();
        }

        private void income_Click(object sender, EventArgs e)
        {
         
        }
    }
}
