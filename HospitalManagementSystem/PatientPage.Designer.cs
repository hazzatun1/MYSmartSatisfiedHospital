namespace HospitalManagementSystem
{
    partial class PatientPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientPage));
            this.listView1 = new System.Windows.Forms.ListView();
            this.P_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p_name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.admit_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.release_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ward_no = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.release_p = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.Empty_ward = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.P_Id,
            this.p_name,
            this.admit_date,
            this.release_date,
            this.ward_no});
            this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(-2, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(631, 568);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // P_Id
            // 
            this.P_Id.Text = "P_Id";
            this.P_Id.Width = 87;
            // 
            // p_name
            // 
            this.p_name.Text = "p_name";
            this.p_name.Width = 116;
            // 
            // admit_date
            // 
            this.admit_date.Text = "admit_date";
            this.admit_date.Width = 147;
            // 
            // release_date
            // 
            this.release_date.Text = "release_date";
            this.release_date.Width = 160;
            // 
            // ward_no
            // 
            this.ward_no.Text = "ward_no";
            this.ward_no.Width = 112;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(825, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(429, 57);
            this.button2.TabIndex = 2;
            this.button2.Text = "Admit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(825, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(429, 64);
            this.button3.TabIndex = 3;
            this.button3.Text = "Doctor_appointment";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(1150, 529);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 41);
            this.button5.TabIndex = 5;
            this.button5.Text = "LogOut";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // release_p
            // 
            this.release_p.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.release_p.Location = new System.Drawing.Point(825, 161);
            this.release_p.Name = "release_p";
            this.release_p.Size = new System.Drawing.Size(429, 59);
            this.release_p.TabIndex = 6;
            this.release_p.Text = "Release";
            this.release_p.UseVisualStyleBackColor = true;
            this.release_p.Click += new System.EventHandler(this.release_p_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Empty_ward});
            this.listView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.Location = new System.Drawing.Point(626, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(193, 568);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // Empty_ward
            // 
            this.Empty_ward.Text = "Empty_ward";
            this.Empty_ward.Width = 188;
            // 
            // PatientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1253, 568);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.release_p);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Name = "PatientPage";
            this.Text = "PatientPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatientPage_FormClosing);
            this.Load += new System.EventHandler(this.PatientPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader P_Id;
        private System.Windows.Forms.ColumnHeader p_name;//
        private System.Windows.Forms.ColumnHeader admit_date;
        private System.Windows.Forms.ColumnHeader release_date;
        private System.Windows.Forms.ColumnHeader ward_no;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button release_p;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader Empty_ward;
    }
}