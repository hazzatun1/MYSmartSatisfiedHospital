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
    public partial class Form1 : Form
    {
        private bool button1WasClicked = false;
        OracleDataReader thisReader;
        public Form1()
        {
            InitializeComponent();
        }

       
        private void logincheck()
        {
            if (!(String.IsNullOrEmpty(textBox1.Text)|| String.IsNullOrEmpty(textBox2.Text))) { 
            try
            {
                
                connection CN = new connection();
                CN.thisConnection.Open();
                OracleCommand thisCommand = new OracleCommand();
                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandText = "SELECT * FROM HOSPITAL_LOGIN WHERE username='" + textBox1.Text + "' AND password='" + textBox2.Text + "'";
                 thisReader = thisCommand.ExecuteReader();

               


                if (thisReader.Read())
                {
            if(comboBox1.Text == "Administrator" && thisReader["designation"].ToString() == "admin")
                    {
                        AdminPage oform = new AdminPage();
                        oform.Show();
                        this.Hide();
                    }
                  else  if (comboBox1.Text == "Doctor" && thisReader["designation"].ToString() == "doctor")
                    {
                            DoctorPage pat = new DoctorPage(textBox1.Text);
                            pat.Show();
                            this.Hide();
                        }
                  else  if (comboBox1.Text == "Receptionist" && thisReader["designation"].ToString() == "pco")
                    {
                        PatientPage oform = new PatientPage();
                        oform.Show();
                        this.Hide();
                    }
                        else if (comboBox1.Text == "Compounder" && thisReader["designation"].ToString() == "compounder")
                        {
                            compounder oform = new compounder();
                            oform.Show();
                            this.Hide();
                        }
                        else if (comboBox1.Text == "Nurse" && thisReader["designation"].ToString() == "nurse")
                        {
                            nurse_page oform = new nurse_page();
                            oform.Show();
                            this.Hide();
                        }
                        else
                    {
                        MessageBox.Show("select your using position");
                    }
                }
                else
                {
                    MessageBox.Show("username or password incorrect");
                }
                //this.Close();
                CN.thisConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            }


            else
            {
                MessageBox.Show("Please input username and password!!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logincheck();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
        }
       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text)) {
                MessageBox.Show("Enter Username");
            }
            else
            {
                connection CN = new connection();
                CN.thisConnection.Open();
                OracleCommand thisCommand = new OracleCommand();
                thisCommand.Connection = CN.thisConnection;
                thisCommand.CommandText = "SELECT * FROM HOSPITAL_LOGIN WHERE username='" + textBox1.Text +"'";
                thisReader = thisCommand.ExecuteReader();
                if (thisReader.Read())
                {
                    Welcome ob = new Welcome(textBox1.Text);
                    ob.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("No account! contact with Admin.");
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(  Keys.Down)) { 

              e.Handled = true; // to prevent system processing

            textBox2.Focus();
            }
         
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {

           e.Handled = true; // to prevent system processing
                textBox1.Focus();
            }
          
        }


        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Up))
            {


                e.Handled = true; // to prevent system processing
                comboBox1.Focus();
                comboBox1.DroppedDown = true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define the border style of the form to a dialog box.
            this.FormBorderStyle = FormBorderStyle.FixedDialog;

            // Set the MaximizeBox to false to remove the maximize box.
            this.MaximizeBox = false;

            // Set the MinimizeBox to false to remove the minimize box.
            this.MinimizeBox = false;

            // Set the start position of the form to the center of the screen.
            this.StartPosition = FormStartPosition.CenterScreen;

            // Display the form as a modal dialog box.
            //this.ShowDialog();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Space))
            {
                textBox1.Focus();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
    }
    }
    

       
           
        
    

