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
    public partial class addData : Form
    {
        string usn = ""; 
        public addData()
        {
            InitializeComponent();
//Guid guid = Guid.NewGuid();
            Random random = new Random();
            int i = random.Next();
            Id.Text = i.ToString().Substring(0, 4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage ob = new AdminPage();
            ob.Show();
            this.Hide();
        }

        private void addData_Load(object sender, EventArgs e)
        {

        }

        private void addData_FormClosing(object sender, FormClosingEventArgs e)
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
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM HOSPITAL_LOGIN where username='"+ un.Text+"'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

            if (!thisReader.Read()) {


            OracleDataAdapter thisAdapter = new OracleDataAdapter(" SELECT * FROM doctor_data", sv.thisConnection);
            OracleDataAdapter thisAdapter2 = new OracleDataAdapter(" SELECT * FROM salary_account ", sv.thisConnection);
            OracleDataAdapter thisAdapter3 = new OracleDataAdapter(" SELECT * FROM hospital_login ", sv.thisConnection);
            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);
            OracleCommandBuilder thisBuilder2 = new OracleCommandBuilder(thisAdapter2);
            OracleCommandBuilder thisBuilder3 = new OracleCommandBuilder(thisAdapter3);
            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "doctor_data");
            DataSet thisDataSet2 = new DataSet();
            thisAdapter2.Fill(thisDataSet2, "salary_account");
            DataSet thisDataSet3 = new DataSet();
            thisAdapter3.Fill(thisDataSet3, "hospital_login");
            DataRow thisRow = thisDataSet.Tables["doctor_data"].NewRow();
            DataRow hello = thisDataSet2.Tables["salary_account"].NewRow();
            DataRow account = thisDataSet3.Tables["hospital_login"].NewRow();

            try
            {

                if (position.Text.Contains("doctor") == true)
                {
                    thisRow["doc_id"] = Id.Text;
                    hello["id"] = Id.Text;
                    thisRow["doc_name"] = em_name.Text;
                    hello["name"] = em_name.Text;
                    thisRow["appointment_time"] = textBox1.Text;
                        thisRow["doc_des"] = Designation.Text;
                        hello["position"] = position.Text;
                    thisRow["ward_no"] = ward_no.Text;
                    thisRow["duty_time"] = DutyTime.Text;
                    hello["join_date"] = dateTimePicker1.Text;
                        thisRow["department"] = depart.Text;
                        hello["duty_time"] = DutyTime.Text;
                    hello["salary"] = salaryBox.Text;
                    hello["accountid"] = acId.Text;
                    account["username"] = un.Text;
                    account["password"] = pass.Text;
                    account["designation"] = position.Text;
                    account["id"] = Id.Text;

                    thisDataSet.Tables["doctor_data"].Rows.Add(thisRow);

                    thisAdapter.Update(thisDataSet, "doctor_data");

                    thisDataSet2.Tables["salary_account"].Rows.Add(hello);

                    thisAdapter2.Update(thisDataSet2, "salary_account");
                    thisDataSet3.Tables["hospital_login"].Rows.Add(account);

                    thisAdapter3.Update(thisDataSet3, "hospital_login");

                    MessageBox.Show("Submitted");
                }
                else if (position.Text.Contains("doctor") == false)
                {



                    hello["id"] = Id.Text;
                    hello["name"] = em_name.Text;
                    hello["position"] = position.Text;
                    hello["join_date"] = dateTimePicker1.Text;
                        hello["duty_time"] = DutyTime.Text;
                        hello["salary"] = salaryBox.Text;
                    hello["accountid"] = acId.Text;
                    account["username"] = un.Text;
                    account["password"] = pass.Text;
                    account["designation"] = position.Text;
                    account["id"] = Id.Text;

                    thisDataSet2.Tables["salary_account"].Rows.Add(hello);
                    thisAdapter2.Update(thisDataSet2, "salary_account");

                    thisDataSet3.Tables["hospital_login"].Rows.Add(account);

                    thisAdapter3.Update(thisDataSet3, "hospital_login");

                    MessageBox.Show("Submitted");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

            AdminPage ob = new AdminPage();
            ob.Show();
            this.Hide();
            }
            else
            {
                MessageBox.Show("username already exists.");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



        private void position_TextChanged(object sender, EventArgs e)
        {
            if (position.Text.Contains("doctor") == true)//char casing changed to lower
            {
                MessageBox.Show("Please enter his department, designation , ward_no and appointment!!!");
            }
            else if (position.Text.Contains("nurse") == true)
            {
                MessageBox.Show("Please enter his ward_no!!!");
            }

        }


        private void Designation_TextChanged(object sender, EventArgs e)
        {
            if (position.Text.Contains("doctor") == false)

            {
                MessageBox.Show("The field reserved for doctor position!!!");
                depart.TextChanged -= Designation_TextChanged;
                depart.Clear();
                depart.TextChanged += Designation_TextChanged;
                
            }
          

        }
   

        private void DutyTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void ward_no_TextChanged(object sender, EventArgs e)
        {
            if ((position.Text.Contains("doctor") == false) && (position.Text.Contains("nurse") == false))

            {
                MessageBox.Show("The field reserved for doctor or nurse position!!!");
                ward_no.TextChanged -= ward_no_TextChanged;
                ward_no.Clear();
                ward_no.TextChanged += ward_no_TextChanged;
            }

            }

        private void depart_TextChanged(object sender, EventArgs e)
        {
            if (position.Text.Contains("doctor") == false)

            {
                MessageBox.Show("The field reserved for doctor position!!!");
                depart.TextChanged -= Designation_TextChanged;
                depart.Clear();
                depart.TextChanged += Designation_TextChanged;

            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (position.Text.Contains("doctor") == false)

            {
                MessageBox.Show("The field reserved for doctor position!!!");
                depart.TextChanged -= Designation_TextChanged;
                depart.Clear();
                depart.TextChanged += Designation_TextChanged;

            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
    }
    



