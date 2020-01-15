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
    public partial class DoctorPage : Form
    {
        
        static DateTime dt = DateTime.Today;
        static string da = DateTime.Now.ToString("dd/MM/yyyy");
        static DateTime firstDay = new DateTime(dt.Year, dt.Month, 1);
        bool dayOfFirstDay = Convert.ToBoolean(firstDay.DayOfWeek);
        static DateTime dt6 = firstDay.AddMonths(+1);
        static string id_doc = "";
        static string name_doc = "";
        static string un = "";


        public DoctorPage()
        {
            InitializeComponent();
        }

        public DoctorPage(string text)
        {
            InitializeComponent();
            un = text;
        }
       

        /*    public DoctorPage(String salDat)
      {
          InitializeComponent();

       salDate = salDat;
      }*/
        private void DoctorPage_Load(object sender, EventArgs e)
        {
            if (dayOfFirstDay)
            {

                textBox1.Text = "Today is Salary";

            }
            else
            {
                textBox1.Text = dt6.ToString();
            }

            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
     "SELECT * FROM doctor_data ";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["doc_id"].ToString();
                lsvItem.SubItems.Add(thisReader["doc_name"].ToString());
                lsvItem.SubItems.Add(thisReader["department"].ToString());
                lsvItem.SubItems.Add(thisReader["ward_no"].ToString());
                lsvItem.SubItems.Add(thisReader["duty_time"].ToString());
                lsvItem.SubItems.Add(thisReader["appointment_time"].ToString());

                listView1.Items.Add(lsvItem);
            }




            OracleCommand thisCommand3 = CN.thisConnection.CreateCommand();
            //  textBox2.Text = "";
            thisCommand3.CommandText =
            "SELECT * FROM HOSPITAL_LOGIN where USERNAME= '" + un + "'";

            OracleDataReader thisReader3 = thisCommand3.ExecuteReader();

            while (thisReader3.Read())
            {
                id_doc = thisReader3["id"].ToString();
             
            }

            OracleCommand thisCommand2 = CN.thisConnection.CreateCommand();
            //  textBox2.Text = "";
            thisCommand2.CommandText =
            "SELECT * FROM doctor_data where doc_id= '" + id_doc + "'";

            OracleDataReader thisReader2 = thisCommand2.ExecuteReader();

            while (thisReader2.Read())
            {
                name_doc = thisReader2["doc_name"].ToString();

            }
            OracleCommand thisCommand4 = CN.thisConnection.CreateCommand();
            //  textBox2.Text = "";
            thisCommand4.CommandText =
            "SELECT * FROM attendance where id= '" + id_doc + "' and date_today='" + da + "'";

            OracleDataReader thisReader4 = thisCommand4.ExecuteReader();

            while (thisReader4.Read())
            {
                textBox2.Text = thisReader4["attendance"].ToString();

            }
            OracleCommand thisCommand5 = CN.thisConnection.CreateCommand();
            //  textBox2.Text = "";
            thisCommand5.CommandText =
            "SELECT * FROM salary_account where id= '" + id_doc + "'";

            OracleDataReader thisReader5 = thisCommand5.ExecuteReader();

            while (thisReader5.Read())
            {
                textBox3.Text = thisReader5["if_paid"].ToString();

            }
            CN.thisConnection.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            connection sv = new connection();
            sv.thisConnection.Open();


            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM attendance", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "attendance");

            DataRow thisRow = thisDataSet.Tables["attendance"].NewRow();
            try
            {

                thisRow["id"] = id_doc;
                thisRow["name"] = name_doc;
                thisRow["position"] = "doctor";
                thisRow["attendance"] = "Y";
                thisRow["date_today"] = da;

                thisDataSet.Tables["attendance"].Rows.Add(thisRow);

                thisAdapter.Update(thisDataSet, "attendance");
                MessageBox.Show("Checked");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            sv.thisConnection.Close();
            this.Hide();
            DoctorPage ob = new DoctorPage();
            ob.Show();

    

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoctorPage_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void button2_Click(object sender, EventArgs e)
        {
            DocAppointment hello = new DocAppointment(un);
            hello.Show();
            this.Hide();
        }

        private void pres_Click(object sender, EventArgs e)
        {
            p_med ob = new p_med();
            ob.Show();
            this.Hide();
        }
    }
}
