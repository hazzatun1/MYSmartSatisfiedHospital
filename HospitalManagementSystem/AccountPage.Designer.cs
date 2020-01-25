namespace HospitalManagementSystem
{
    partial class AccountPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountPage));
            this.label4 = new System.Windows.Forms.Label();
            this.employee = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.service = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.canteen = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(822, 531);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 31);
            this.label4.TabIndex = 18;
            this.label4.Text = "Outgoing Management";
            // 
            // employee
            // 
            this.employee.BackColor = System.Drawing.Color.LavenderBlush;
            this.employee.Image = ((System.Drawing.Image)(resources.GetObject("employee.Image")));
            this.employee.Location = new System.Drawing.Point(616, 2);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(653, 526);
            this.employee.TabIndex = 17;
            this.employee.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 531);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Income Management";
            // 
            // service
            // 
            this.service.BackColor = System.Drawing.Color.GreenYellow;
            this.service.Image = ((System.Drawing.Image)(resources.GetObject("service.Image")));
            this.service.Location = new System.Drawing.Point(2, 2);
            this.service.Name = "service";
            this.service.Size = new System.Drawing.Size(618, 526);
            this.service.TabIndex = 14;
            this.service.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-478, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "Canteen Management";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(-101, -3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 0);
            this.button3.TabIndex = 11;
            this.button3.Text = "Patient Coordinator";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // canteen
            // 
            this.canteen.BackColor = System.Drawing.Color.Red;
            this.canteen.ForeColor = System.Drawing.Color.Black;
            this.canteen.Image = ((System.Drawing.Image)(resources.GetObject("canteen.Image")));
            this.canteen.Location = new System.Drawing.Point(-491, -3);
            this.canteen.Name = "canteen";
            this.canteen.Size = new System.Drawing.Size(319, 217);
            this.canteen.TabIndex = 10;
            this.canteen.UseVisualStyleBackColor = false;
            // 
            // back
            // 
            this.back.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.Location = new System.Drawing.Point(1183, 531);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(86, 31);
            this.back.TabIndex = 19;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // AccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 559);
            this.Controls.Add(this.back);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.employee);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.service);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.canteen);
            this.Name = "AccountPage";
            this.Text = "AccountPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button employee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button service;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button canteen;
        private System.Windows.Forms.Button back;
    }
}