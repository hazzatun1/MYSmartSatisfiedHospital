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
    public partial class p_med : Form     
    {
        static string d_name = "";

        public p_med()
        {
            InitializeComponent();

        }
        public p_med(string name_doc)
             {
            InitializeComponent();
            d_name = name_doc;
            make_comboBox();
        }

        public void make_comboBox()
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            string query = "SELECT * FROM patient_data where REFDOCTOR = '" + d_name + "' ";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();

            try
            {

                while (myReader.Read())
                {

                    comboBox1.Items.Add(myReader.GetString(myReader.GetOrdinal("p_id")));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

        }


        static   DateTime tda = DateTime.Today;
        string td = tda.ToString();
        private string un;

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorPage ob = new DoctorPage();
            ob.Show();
            this.Hide();
        }

        private void p_med_Load(object sender, EventArgs e)
        { }
        

        private void p_id_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM doc_pres", sv.thisConnection);

            OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

            DataSet thisDataSet = new DataSet();
            thisAdapter.Fill(thisDataSet, "doc_pres");

            DataRow thisRow = thisDataSet.Tables["doc_pres"].NewRow();
            try
            {

                thisRow["p_id"] = comboBox1.Text;
                thisRow["med"] = textBox1.Text;
                thisRow["MORN_BE_FOOD"] = checkBox1.Text;
                thisRow["MORN_AF_FOOD"] = checkBox2.Text;
                thisRow["AFNN_BE_FOOD"] = checkBox3.Text;
                thisRow["AFNN_AF_FOOD"] = checkBox4.Text;
                thisRow["NIGHT_BE_FOOD"] = checkBox5.Text;
                thisRow["NIGHT_AF_FOOD"] = checkBox6.Text;
                thisRow["IF_NEED"] = checkBox7.Text;
                thisRow["T_DATE"] = td;
                

                thisDataSet.Tables["doc_pres"].Rows.Add(thisRow);



                thisAdapter.Update(thisDataSet, "doc_pres");
                MessageBox.Show("Submitted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox1.Text = "1";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox2.Text = "1";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox3.Text = "1";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox4.Text = "1";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox5.Text = "1";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox6.Text = "1";
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBox7.Text = "1";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        
    }
}
