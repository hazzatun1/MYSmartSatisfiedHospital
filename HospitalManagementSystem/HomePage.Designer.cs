namespace HospitalManagementSystem
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.canteen = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.account = new System.Windows.Forms.Button();
            this.service = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.employee = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // canteen
            // 
            this.canteen.BackColor = System.Drawing.Color.Red;
            this.canteen.ForeColor = System.Drawing.Color.Black;
            this.canteen.Image = ((System.Drawing.Image)(resources.GetObject("canteen.Image")));
            this.canteen.Location = new System.Drawing.Point(-1, 2);
            this.canteen.Name = "canteen";
            this.canteen.Size = new System.Drawing.Size(319, 514);
            this.canteen.TabIndex = 0;
            this.canteen.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(389, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 0);
            this.button3.TabIndex = 2;
            this.button3.Text = "Patient Coordinator";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Canteen Management";
            // 
            // account
            // 
            this.account.BackColor = System.Drawing.Color.DarkOrange;
            this.account.Image = ((System.Drawing.Image)(resources.GetObject("account.Image")));
            this.account.Location = new System.Drawing.Point(314, 2);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(319, 514);
            this.account.TabIndex = 4;
            this.account.UseVisualStyleBackColor = false;
            // 
            // service
            // 
            this.service.BackColor = System.Drawing.Color.GreenYellow;
            this.service.Image = ((System.Drawing.Image)(resources.GetObject("service.Image")));
            this.service.Location = new System.Drawing.Point(628, 2);
            this.service.Name = "service";
            this.service.Size = new System.Drawing.Size(319, 514);
            this.service.TabIndex = 5;
            this.service.UseVisualStyleBackColor = false;
            this.service.Click += new System.EventHandler(this.service_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(333, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 31);
            this.label2.TabIndex = 6;
            this.label2.Text = "Account Management";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(649, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(269, 31);
            this.label3.TabIndex = 7;
            this.label3.Text = "Service Management";
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.Color.LavenderBlush;
            this.employee.Image = ((System.Drawing.Image)(resources.GetObject("employee.Image")));
            this.employee.Location = new System.Drawing.Point(946, 2);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(319, 514);
            this.employee.TabIndex = 8;
            this.employee.UseVisualStyleBackColor = false;
            this.employee.Click += new System.EventHandler(this.employee_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(953, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Employee Management";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 559);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.employee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.service);
            this.Controls.Add(this.account);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.canteen);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button canteen;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button account;
        private System.Windows.Forms.Button service;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button employee;
        private System.Windows.Forms.Label label4;
    }
}