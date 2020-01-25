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
    public partial class AccountPage : Form
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, EventArgs e)
        {
            AccountHome oform = new AccountHome();
            oform.Show();
            this.Hide();
        }
    }
}
