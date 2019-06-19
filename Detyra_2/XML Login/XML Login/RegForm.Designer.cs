namespace XML_Login
{
    partial class RegForm
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
            this.register = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.Label();
            this.salary = new System.Windows.Forms.Label();
            this.name1 = new System.Windows.Forms.TextBox();
            this.pos1 = new System.Windows.Forms.TextBox();
            this.pay1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(106, 198);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(75, 23);
            this.register.TabIndex = 0;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(48, 69);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(38, 13);
            this.name.TabIndex = 1;
            this.name.Text = "Name:";
            // 
            // position
            // 
            this.position.AutoSize = true;
            this.position.Location = new System.Drawing.Point(39, 108);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(44, 13);
            this.position.TabIndex = 2;
            this.position.Text = "Faculty:";
            // 
            // salary
            // 
            this.salary.AutoSize = true;
            this.salary.Location = new System.Drawing.Point(47, 150);
            this.salary.Name = "salary";
            this.salary.Size = new System.Drawing.Size(50, 13);
            this.salary.TabIndex = 3;
            this.salary.Text = "Average:";
            // 
            // name1
            // 
            this.name1.Location = new System.Drawing.Point(92, 66);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(129, 20);
            this.name1.TabIndex = 4;
            this.name1.TextChanged += new System.EventHandler(this.name1_TextChanged);
            // 
            // pos1
            // 
            this.pos1.Location = new System.Drawing.Point(92, 105);
            this.pos1.Name = "pos1";
            this.pos1.Size = new System.Drawing.Size(129, 20);
            this.pos1.TabIndex = 5;
            // 
            // pay1
            // 
            this.pay1.Location = new System.Drawing.Point(92, 147);
            this.pay1.Name = "pay1";
            this.pay1.Size = new System.Drawing.Size(129, 20);
            this.pay1.TabIndex = 6;
            // 
            // RegForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pay1);
            this.Controls.Add(this.pos1);
            this.Controls.Add(this.name1);
            this.Controls.Add(this.salary);
            this.Controls.Add(this.position);
            this.Controls.Add(this.name);
            this.Controls.Add(this.register);
            this.Name = "RegForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Register2;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label position;
        private System.Windows.Forms.Label salary;
        private System.Windows.Forms.TextBox name1;
        private System.Windows.Forms.TextBox pos1;
        private System.Windows.Forms.TextBox pay1;
    }
}