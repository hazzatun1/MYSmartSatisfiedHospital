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
    public partial class AdmitForm : Form
    {
        int result=0;
        string res = "";
        public AdmitForm()
        {
            InitializeComponent();
            make_comboBox();
            make_comboBox2();
            make_p_id();
        }
        private bool button2WasClicked = false;
        private void button3_Click(object sender, EventArgs e)
        {
            PatientPage ob = new PatientPage();
            ob.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button2WasClicked == true)
            {
                MessageBox.Show("Now Print");
            }
            else
            {
                MessageBox.Show("Insert before Print");
            }
        }

        void make_comboBox()
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            string query = "SELECT * FROM DOCTOR_DATA ";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();

            try
            {

                while (myReader.Read())
                {

                    comboBox1.Items.Add(myReader.GetString(myReader.GetOrdinal("doc_name")));

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
        }

       public void make_comboBox2()
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            string query = "SELECT * FROM ward_allocation order by ward_no ";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();

            try
            {

                while (myReader.Read())
                {

                    ward_no.Items.Add(myReader.GetString(myReader.GetOrdinal("empty_ward")));

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
        }
       public void make_p_id()
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            string query = "SELECT * FROM ward_allocation order by empty_ward desc";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();
           String Yes = "Yes";
            string query2 = "SELECT * FROM patient_data where if_release_paid='"+Yes+ "'";


            OracleCommand cmddatabase2 = new OracleCommand(query2, sv.thisConnection);

            OracleDataReader myReader2 = cmddatabase2.ExecuteReader();

            try
            {

                while (myReader.Read()&& myReader2.Read())
                {
                    if (myReader["bed_free"].ToString() != "0") {
                        if (myReader2["if_release_paid"].ToString() == "Yes")
                        {
                            p_id.Text = myReader2["p_id"].ToString();
                        }
                        else
                        {
                            p_id.Text = myReader["empty_ward"].ToString() + myReader["bed_free"].ToString();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            button2WasClicked = true;

            connection sv = new connection();
            sv.thisConnection.Open();
            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM patient_data", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "patient_data");

            DataRow thisRow = thisDataSet.Tables["patient_data"].NewRow();
            try
            {
                thisRow["p_id"] = p_id.Text;
                thisRow["p_name"] = p_name.Text;
                thisRow["p_mobile"] = p_mob.Text;
                thisRow["address"] = p_add.Text;
                thisRow["refdoctor"] = comboBox1.Text;
                thisRow["admit_date"] = dateTimePicker1.Value.ToString();
                thisRow["ward_no"] = ward_no.Text;
                thisRow["total_cost"] = textBox1.Text;
                thisRow["if_paid"] = "Yes";
                thisRow["release_date"] ="0";

                thisDataSet.Tables["patient_data"].Rows.Add(thisRow);

                int a = thisAdapter.Update(thisDataSet, "patient_data");

                if (a == 1)
                    MessageBox.Show("Successful");
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


            if (!String.IsNullOrEmpty(ward_no.Text))
            {
                OracleCommand thisCommand4 = sv.thisConnection.CreateCommand();
                thisCommand4.CommandText =
               "SELECT * FROM ward_allocation where ward_no= '" + ward_no.Text + "'";

                OracleDataReader thisReader3 = thisCommand4.ExecuteReader();
             //  
                while (thisReader3.Read())
                {
                    string cmd2 = thisReader3["bed_free"].ToString();
                    int cc2 = Convert.ToInt32(cmd2);
                    
                    
                    if (cc2 > 0)
                    {
                        result = (cc2 - 1);
                        res = result.ToString();
                    }

                    else
                    {
                        res = "0";
                    }


                    if (cmd2 != "0")
                    {
                        OracleCommand thisCommand5 = sv.thisConnection.CreateCommand();
                        thisCommand5.CommandText =
                "update ward_allocation set  empty_ward = ward_no where ward_no= '" + ward_no.Text + "'";

                        OracleDataReader thisReader4 = thisCommand5.ExecuteReader();
                    }

                    else if (cmd2 == "0")
                    {
                        OracleCommand thisCommand6 = sv.thisConnection.CreateCommand();
                        thisCommand6.CommandText =
                "update ward_allocation set  empty_ward = 0 where ward_no= '" + ward_no.Text + "'";

                        OracleDataReader thisReader7 = thisCommand6.ExecuteReader();
                    }

                    OracleCommand thisCommand3 = sv.thisConnection.CreateCommand();
                thisCommand3.CommandText =
               "update ward_allocation set " +
               "bed_free='" + res + "' where ward_no= '" + ward_no.Text + "'";

                thisCommand3.Connection = sv.thisConnection;
                thisCommand3.CommandType = CommandType.Text;
                    try
                    {
                        thisCommand3.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

            sv.thisConnection.Close();
            PatientPage ob = new PatientPage();
            ob.Show();
            this.Hide();
        }

        private void AdmitForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void p_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
