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
    public partial class editData : Form
    {
        public editData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminPage ob = new AdminPage();
            ob.Show();
            this.Hide();
        }

        private void editData_FormClosing(object sender, FormClosingEventArgs e)
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

    

 

        private void Id_TextChanged(object sender, EventArgs e)
        {
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();
            em_name.Text = "";
            DutyTime.Text = "";
            salaryBox.Text = "";
            acId.Text = "";
            un.Text = "";
            position.Text = "";
            depart.Text = "";
            Designation.Text = "";
            appt.Text = "";
            ward_no.Text = "";



            thisCommand.CommandText =
            "SELECT * FROM hospital_login where id= '" + em_id.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();
            OracleCommand thisCommand2 = CN.thisConnection.CreateCommand();
            thisCommand2.CommandText =
           "SELECT * FROM salary_account where id= '" + em_id.Text + "'";

            OracleDataReader thisReader2 = thisCommand2.ExecuteReader();
            OracleCommand thisCommand3 = CN.thisConnection.CreateCommand();
            thisCommand3.CommandText =
           "SELECT * FROM doctor_data where doc_id= '" + em_id.Text + "'";

            OracleDataReader thisReader3 = thisCommand3.ExecuteReader();

            while (thisReader2.Read())
            {
               
                if (thisReader2["POSITION"].ToString()=="doctor")
                {
                    while (thisReader3.Read() &&  thisReader.Read())
                    {
                        try
                        {
                            un.Text = thisReader["username"].ToString();
                            DutyTime.Text = thisReader2["duty_time"].ToString();
                            salaryBox.Text = thisReader2["salary"].ToString();
                            acId.Text = thisReader2["ACCOUNTID"].ToString();
                            position.Text = thisReader2["position"].ToString();


                            em_name.Text = thisReader3["doc_name"].ToString();
                            depart.Text = thisReader3["department"].ToString();
                            Designation.Text = thisReader3["designation"].ToString();
                            appt.Text = thisReader3["appointment_time"].ToString();
                            ward_no.Text = thisReader3["ward_no"].ToString();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }

                    }
                }
                else if (thisReader2["position"].ToString() != "doctor")
                {
                    while (  thisReader.Read())
                    {


                        try
                        {
                            em_name.Text = thisReader2["name"].ToString();
                            DutyTime.Text = thisReader2["duty_time"].ToString();
                            salaryBox.Text = thisReader2["salary"].ToString();
                            position.Text = thisReader2["position"].ToString();
                            acId.Text = thisReader2["ACCOUNTID"].ToString();
                            un.Text = thisReader["username"].ToString();
                        
                         

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message); }
                    }

                }
              
            }


            }

        private void Edit_Click(object sender, EventArgs e)
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            OracleCommand thisCommand1 = sv.thisConnection.CreateCommand();

            thisCommand1.CommandText =
                "update HOSPITAL_LOGIN set username= '" + un.Text + "', " +
                "designation='" + position.Text + "' where id= '" + em_id.Text + "'";

            thisCommand1.Connection = sv.thisConnection;
            thisCommand1.CommandType = CommandType.Text;

            OracleCommand thisCommand2 = sv.thisConnection.CreateCommand();
            thisCommand2.CommandText =
               "update salary_account set name= '" + em_name.Text + "', salary='" + salaryBox.Text + "', " +
               "position='" + position.Text + "',accountid='" + acId.Text + "', duty_time= '" + DutyTime.Text + "' where id= '" + em_id.Text + "'";

            thisCommand2.Connection = sv.thisConnection;
            thisCommand2.CommandType = CommandType.Text;

            OracleCommand thisCommand3 = sv.thisConnection.CreateCommand();
            thisCommand3.CommandText =
               "update doctor_data set doc_name= '" + em_name.Text + "', ward_no= '" + ward_no.Text + "', department = '" + depart.Text + "', " +
               "designation='" + Designation.Text + "', duty_time = '" + DutyTime.Text + "', appointment_time = '" + appt.Text + "' where doc_id= '" + em_id.Text + "'";

            thisCommand3.Connection = sv.thisConnection;
            thisCommand3.CommandType = CommandType.Text;


            try
            {
                thisCommand1.ExecuteNonQuery();
                thisCommand2.ExecuteNonQuery();
                thisCommand3.ExecuteNonQuery();
                MessageBox.Show("Updated");
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
 
            sv.thisConnection.Close();
           this.Hide();
           editData ob = new editData();
           ob.Show();
        }



    }
        }
    

