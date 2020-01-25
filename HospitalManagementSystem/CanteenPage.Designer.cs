namespace HospitalManagementSystem
{
    partial class CanteenPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanteenPage));
            this.label4 = new System.Windows.Forms.Label();
            this.employee = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.service = new System.Windows.Forms.Button();
            this.account = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.canteen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1066, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 31);
            this.label4.TabIndex = 25;
            this.label4.Text = "Cost";
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.Color.LavenderBlush;
            this.employee.Image = ((System.Drawing.Image)(resources.GetObject("employee.Image")));
            this.employee.Location = new System.Drawing.Point(948, 0);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(319, 516);
            this.employee.TabIndex = 24;
            this.employee.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(736, 519);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 31);
            this.label3.TabIndex = 23;
            this.label3.Text = "Item ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(382, 519);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 31);
            this.label2.TabIndex = 22;
            this.label2.Text = "DoctorFood";
            // 
            // service
            // 
            this.service.BackColor = System.Drawing.Color.GreenYellow;
            this.service.Image = ((System.Drawing.Image)(resources.GetObject("service.Image")));
            this.service.Location = new System.Drawing.Point(633, 0);
            this.service.Name = "service";
            this.service.Size = new System.Drawing.Size(319, 516);
            this.service.TabIndex = 21;
            this.service.UseVisualStyleBackColor = false;
            // 
            // account
            // 
            this.account.BackColor = System.Drawing.Color.DarkOrange;
            this.account.Image = ((System.Drawing.Image)(resources.GetObject("account.Image")));
            this.account.Location = new System.Drawing.Point(316, 0);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(319, 516);
            this.account.TabIndex = 20;
            this.account.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 31);
            this.label1.TabIndex = 19;
            this.label1.Text = "PatientFood";
            // 
            // canteen
            // 
            this.canteen.BackColor = System.Drawing.Color.Red;
            this.canteen.ForeColor = System.Drawing.Color.Black;
            this.canteen.Image = ((System.Drawing.Image)(resources.GetObject("canteen.Image")));
            this.canteen.Location = new System.Drawing.Point(1, 0);
            this.canteen.Name = "canteen";
            this.canteen.Size = new System.Drawing.Size(319, 516);
            this.canteen.TabIndex = 18;
            this.canteen.UseVisualStyleBackColor = false;
            // 
            // CanteenPage
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
            this.Controls.Add(this.canteen);
            this.Name = "CanteenPage";
            this.Text = "CanteenPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button employee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button service;
        private System.Windows.Forms.Button account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button canteen;
    }
}