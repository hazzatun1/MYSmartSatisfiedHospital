using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void employee_Click(object sender, EventArgs e)
        {

        }

        private void service_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
        }

        private void account_Click(object sender, EventArgs e)
        {
            AccountHome ob = new AccountHome();
            ob.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
