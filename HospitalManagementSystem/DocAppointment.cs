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
using System.Drawing.Printing;

namespace HospitalManagementSystem
{
    public partial class DocAppointment : Form
    {

        static string doc_un = "";
        static string doc_id = "";


        public DocAppointment()
        {
            InitializeComponent();
           
        }

        public DocAppointment(string text)
        {
            InitializeComponent();
            doc_un = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoctorPage ob = new DoctorPage();
            ob.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
      public  void ins() { 
        if (String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox6.Text) || String.IsNullOrEmpty(textBox6.Text)
                || String.IsNullOrEmpty(textBox10.Text))
            {
                MessageBox.Show("Please Instruction to contact compounder!!!!");
            }
        }

        
           

        private void DocAppointment_Load(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand dn = CN.thisConnection.CreateCommand();

            dn.CommandText =
            "SELECT * FROM hospital_login where username= '" + doc_un + "'";

            OracleDataReader thisReader3 = dn.ExecuteReader();


            while (thisReader3.Read())
            {

                try
                {
                    doc_id = thisReader3["id"].ToString();
                }
                catch
                {
                    MessageBox.Show("Failure");
                }
            }

            OracleCommand doc_pro = CN.thisConnection.CreateCommand();
            
            dp.Text = "";
            doc_pro.CommandText =
        "SELECT * FROM doctor_data where doc_id= '" + doc_id + "'";

            OracleDataReader thisReader4 = doc_pro.ExecuteReader();


            while (thisReader4.Read())
            {
                try
                {
                    string hhh = "Doctor Profile: ";
                    string newLine = Environment.NewLine;
                    string name = thisReader4["doc_name"].ToString();
                    string dep = thisReader4["department"].ToString();
                    string des= thisReader4["designation"].ToString();
                    string app = thisReader4["appointment_time"].ToString();
                    dp.Text = hhh+ newLine + name+ newLine + dep+" "+ des + newLine +"appointment time:"+ app+ newLine+"My Hospital";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }


            string no = "No";
            

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
    "SELECT * FROM doctor_appointment where visit_status='"+ no+"'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();

            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["token_id"].ToString();
                lsvItem.SubItems.Add(thisReader["patient_name"].ToString());
                lsvItem.SubItems.Add(thisReader["req_date"].ToString());
                lsvItem.SubItems.Add(thisReader["mobile"].ToString());

                listView1.Items.Add(lsvItem);
            }

         
                CN.thisConnection.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
         
        }

        //  Bitmap bitmap;
        private void button2_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();

            string yes = "Yes";

            OracleCommand thisCommand = sv.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "update doctor_appointment set visit_status = '" + yes + "' where token_id= '" + textBox1.Text + "'";

            thisCommand.Connection = sv.thisConnection;
            thisCommand.CommandType = CommandType.Text;
            //For Insert Data Into Oracle//
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please write something to advice!!!!");

            }
            else if (!String.IsNullOrEmpty(textBox3.Text)){
            try
            {
               

                thisCommand.ExecuteNonQuery();

                    PrintDocument doc = new PrintDocument();
                    doc.DefaultPageSettings.Landscape = true;
                    doc.PrintPage += this.printDocument1_PrintPage;
                    PrintDialog dlgSettings = new PrintDialog();
                    dlgSettings.Document = doc;
                    if (dlgSettings.ShowDialog() == DialogResult.OK)
                    {
                        doc.Print();
                    }


                    //   MessageBox.Show("submitted");
                    this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
                
            
            sv.thisConnection.Close();

             
              
            DocAppointment ob = new DocAppointment();
            ob.Show();
            }
        }

 
    

        private void DocAppointment_FormClosing(object sender, FormClosingEventArgs e)
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float x = e.MarginBounds.Left;
            float y = e.MarginBounds.Top;
            Bitmap bmp = new Bitmap(this.groupBox1.Width, this.groupBox1.Height);
            this.groupBox1.DrawToBitmap(bmp, new Rectangle(0, 0, this.groupBox1.Width, this.groupBox1.Height));
            e.Graphics.DrawImage((Image)bmp, x, y);
        }

        private void pn_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            pn.Text = "";
            pa.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox10.Text = "";
            thisCommand.CommandText =
            "SELECT * FROM doctor_appointment where token_id= '" + textBox1.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                try
                {
                    pn.Text = thisReader["patient_name"].ToString();
                    pa.Text = thisReader["p_age"].ToString();
                    textBox6.Text = thisReader["weight_kg"].ToString();
                    textBox7.Text = thisReader["pulse_min"].ToString();
                    textBox8.Text = thisReader["bp"].ToString();
                    textBox10.Text = thisReader["additional_info"].ToString();
                }
                catch
                { MessageBox.Show("Failure"); }
                ins();

            }
        }
    }
}
