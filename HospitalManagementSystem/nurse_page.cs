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
  
    public partial class nurse_page : Form
    {
        String UserName;
        Timer t = new Timer();
        public nurse_page()
        {
            InitializeComponent();
            
        }

        public nurse_page(string text)
        {
            UserName = text;
        }

        static DateTime da = DateTime.Now;
       static string today = da.ToString();

        private void nurse_page_Load(object sender, EventArgs e)
        {
            t.Interval = 100;  //in milliseconds

            t.Tick += new EventHandler(this.timer1_Tick);

            //start timer when form loads
            t.Start();  //this will use t_Tick() method

            loading();


        }
        void loading()
        {
            connection CN = new connection();
            CN.thisConnection.Open();


            OracleCommand thisCommand1 = CN.thisConnection.CreateCommand();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
    "SELECT * FROM doc_pres";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["p_id"].ToString();
                lsvItem.SubItems.Add(thisReader["med"].ToString());
                lsvItem.SubItems.Add(thisReader["morn_be_food"].ToString());
                lsvItem.SubItems.Add(thisReader["morn_af_food"].ToString());
                lsvItem.SubItems.Add(thisReader["afnn_be_food"].ToString());
                lsvItem.SubItems.Add(thisReader["afnn_af_food"].ToString());
                lsvItem.SubItems.Add(thisReader["night_be_food"].ToString());
                lsvItem.SubItems.Add(thisReader["night_af_food"].ToString());
                lsvItem.SubItems.Add(thisReader["if_need"].ToString());
                lsvItem.SubItems.Add(thisReader["t_date"].ToString());
                listView2.Items.Add(lsvItem);
            }


            CN.thisConnection.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            comboBox1.Items.Clear();
            make_comboBox();
            liv();
        }
       public void liv()
        {

            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
    "SELECT * FROM prescription where p_id='" + textBox1.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {
                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["med"].ToString();
                lsvItem.SubItems.Add(thisReader["YES"].ToString());
               
                lsvItem.SubItems.Add(thisReader["t_date"].ToString());

                listView1.Items.Add(lsvItem);
                
            }

            CN.thisConnection.Close();
         
        }


          public  void make_comboBox()
        {
            connection sv = new connection();
            sv.thisConnection.Open();
            string query = "SELECT * FROM doc_pres where p_id='" + textBox1.Text + "' ";


            OracleCommand cmddatabase = new OracleCommand(query, sv.thisConnection);

            OracleDataReader myReader = cmddatabase.ExecuteReader();

            try
            {

                while (myReader.Read())
                {

                    comboBox1.Items.Add(myReader.GetString(myReader.GetOrdinal("med")));
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sv.thisConnection.Close();
          
        }

       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if(mtime.Text!=" No Medicine Time Now") {
                connection sv = new connection();
                sv.thisConnection.Open();

                OracleDataAdapter thisAdapter = new OracleDataAdapter("SELECT * FROM prescription", sv.thisConnection);

                OracleCommandBuilder thisBuilder = new OracleCommandBuilder(thisAdapter);

                DataSet thisDataSet = new DataSet();
                thisAdapter.Fill(thisDataSet, "prescription");

                DataRow thisRow = thisDataSet.Tables["prescription"].NewRow();
                try
                {

                    thisRow["p_id"] = textBox1.Text;
                    thisRow["med"] = comboBox1.Text;
                    thisRow["YES"] = mtime.Text;
                    thisRow["t_date"] = today;


                    thisDataSet.Tables["prescription"].Rows.Add(thisRow);



                    thisAdapter.Update(thisDataSet, "prescription");
                    MessageBox.Show("Checked");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                sv.thisConnection.Close();
                this.Hide();
                nurse_page ob = new nurse_page();
                ob.Show();
            }
           else
            {
                MessageBox.Show("No medicine can be applied now");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ob = new Form1();
            ob.Show();
            this.Hide();
        }
   

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           


        }

        private void nurse_page_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            // string hel1 = "7:30 AM";
            // DateTime hello = Convert.ToDateTime(hel1);
            //  DateTime  now = DateTime.ParseExact("12:00:00 AM", "M/d/yyyyh:mm:ss tt", CultureInfo.InvariantCulture);;
            DateTime now = DateTime.Now;
            string mornbfood = "7:00 AM";
            DateTime time1 = Convert.ToDateTime(mornbfood);
            string mornbfood2 = "7:30 AM";
            DateTime time2 = Convert.ToDateTime(mornbfood2);

            string morn_af_food1 = "8:30 AM";
            DateTime morn_af_food1_time1 = Convert.ToDateTime(morn_af_food1);
            string morn_af_food2 = "9:00 AM";
            DateTime morn_af_food1_time2 = Convert.ToDateTime(morn_af_food2);


            string af_be_food1 = "12:00 PM";
            DateTime af_be_food1_time1 = Convert.ToDateTime(af_be_food1);
            string af_be_food2 = "12:30 PM";
            DateTime af_be_food1_time2 = Convert.ToDateTime(af_be_food2);

            string af_af_food1 = "1:30 PM";
            DateTime af_af_food_time1 = Convert.ToDateTime(af_af_food1);
            string af_af_food2 = "2:00 PM";
            DateTime af_af_food_time2 = Convert.ToDateTime(af_af_food2);

            string n_be_food = "6:00 PM";
            DateTime n_be_food_time1 = Convert.ToDateTime(n_be_food);
            string n_be_food2 = "6:30 PM";
            DateTime n_be_food_time2 = Convert.ToDateTime(n_be_food2);

            string n_af_food = "7:30 PM";
            DateTime n_af_food_time1 = Convert.ToDateTime(n_af_food);
            string n_af_food2 = "8:00 PM";
            DateTime n_af_food_time2 = Convert.ToDateTime(n_af_food2);


            if (time1 < now && now < time2)
            {
                mtime.Text = "Morning before food";
            }
            else if (morn_af_food1_time1 < now && now < morn_af_food1_time2)
            {
                mtime.Text = "Morning after food";
            }

            else if (af_be_food1_time1 < now && now < af_be_food1_time2)
            {
                mtime.Text = "Afternoon before food";
            }


            else if (af_af_food_time1 < now && now < af_af_food_time2)
            {
                mtime.Text = "Afternoon after food";
            }

            else if (n_be_food_time1 < now && now < n_be_food_time2)
            {
                mtime.Text = "Night before food";
            }

            else if (n_af_food_time1 < now && now < n_af_food_time2)
            {
                mtime.Text = "Night after food";
            }
            else
            {
                mtime.Text = "No Medicine Time Now";
            }

        }

        private void searchBox_Enter(object sender, EventArgs e)
        {
            if(searchBox.Text=="Search By Patient Id")
            {
                searchBox.Text = "";
                searchBox.ForeColor = Color.Black;

            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

            listView2.Items.Clear();
            connection CN = new connection();
            CN.thisConnection.Open();

            OracleCommand thisCommand = CN.thisConnection.CreateCommand();

            thisCommand.CommandText =
                "SELECT * FROM doc_pres where p_id='" + searchBox.Text + "'";

            OracleDataReader thisReader = thisCommand.ExecuteReader();


            while (thisReader.Read())
            {

                ListViewItem lsvItem = new ListViewItem();
                lsvItem.Text = thisReader["p_id"].ToString();
                lsvItem.SubItems.Add(thisReader["med"].ToString());
                lsvItem.SubItems.Add(thisReader["morn_be_food"].ToString());
                lsvItem.SubItems.Add(thisReader["morn_af_food"].ToString());
                lsvItem.SubItems.Add(thisReader["afnn_be_food"].ToString());
                lsvItem.SubItems.Add(thisReader["afnn_af_food"].ToString());
                lsvItem.SubItems.Add(thisReader["night_be_food"].ToString());
                lsvItem.SubItems.Add(thisReader["night_af_food"].ToString());
                lsvItem.SubItems.Add(thisReader["if_need"].ToString());
                lsvItem.SubItems.Add(thisReader["t_date"].ToString());

                listView2.Items.Add(lsvItem);
            }


            CN.thisConnection.Close();
        }

        private void searchBox_Leave(object sender, EventArgs e)
        {
            if (searchBox.Text == "")
            {
                searchBox.Text = "Search By Patient Id";
                searchBox.ForeColor = Color.Red;
                loading();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void mtime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
