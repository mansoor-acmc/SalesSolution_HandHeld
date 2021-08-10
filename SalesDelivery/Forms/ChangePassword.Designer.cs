namespace SalesDelivery
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.btnDelete = new System.Windows.Forms.Button();
            this.colUsername = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.colPassword = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridTextBoxColumn();
            this.colUserId = new System.Windows.Forms.DataGridTextBoxColumn();
            this.gridPasswords = new System.Windows.Forms.DataGrid();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Users = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu2
            // 
            this.mainMenu2.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.MenuItems.Add(this.menuItem2);
            this.menuItem1.Text = "&File";
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "&Close";
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDelete.Location = new System.Drawing.Point(0, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 34);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // colUsername
            // 
            this.colUsername.Format = "";
            this.colUsername.FormatInfo = null;
            this.colUsername.HeaderText = "UserName";
            this.colUsername.MappingName = "UserName";
            this.colUsername.Width = 120;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colUsername);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colPassword);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colRole);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.colUserId);
            this.dataGridTableStyle1.MappingName = "Users";
            // 
            // colPassword
            // 
            this.colPassword.Format = "";
            this.colPassword.FormatInfo = null;
            this.colPassword.HeaderText = "Password";
            this.colPassword.MappingName = "Password";
            this.colPassword.Width = 0;
            // 
            // colRole
            // 
            this.colRole.Format = "";
            this.colRole.FormatInfo = null;
            this.colRole.HeaderText = "Role";
            this.colRole.MappingName = "Role";
            this.colRole.Width = 100;
            // 
            // colUserId
            // 
            this.colUserId.Format = "";
            this.colUserId.FormatInfo = null;
            this.colUserId.HeaderText = "UserId";
            this.colUserId.MappingName = "UserId";
            this.colUserId.Width = 0;
            // 
            // gridPasswords
            // 
            this.gridPasswords.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPasswords.Location = new System.Drawing.Point(4, 24);
            this.gridPasswords.Name = "gridPasswords";
            this.gridPasswords.Size = new System.Drawing.Size(232, 133);
            this.gridPasswords.TabIndex = 19;
            this.gridPasswords.TableStyles.Add(this.dataGridTableStyle1);
            this.gridPasswords.DoubleClick += new System.EventHandler(this.gridPasswords_DoubleClick);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbRole);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tbUserName);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(4, 157);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 107);
            // 
            // cmbRole
            // 
            this.cmbRole.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbRole.Items.Add("Employee");
            this.cmbRole.Items.Add("Supervisor");
            this.cmbRole.Items.Add("Admin");
            this.cmbRole.Location = new System.Drawing.Point(53, 81);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(103, 22);
            this.cmbRole.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(0, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 26);
            this.label9.Text = "Role:";
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(0, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(156, 5);
            // 
            // tbPassword
            // 
            this.tbPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbPassword.Location = new System.Drawing.Point(0, 55);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(156, 21);
            this.tbPassword.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 15);
            this.label5.Text = "Password:";
            // 
            // tbUserName
            // 
            this.tbUserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbUserName.Location = new System.Drawing.Point(0, 19);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(156, 21);
            this.tbUserName.TabIndex = 5;
            this.tbUserName.Tag = "0";
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(156, 15);
            this.label8.Text = "Username:";
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Right;
            this.label7.Location = new System.Drawing.Point(156, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(3, 103);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(159, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(73, 103);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSave.Location = new System.Drawing.Point(0, 34);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 34);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(73, 34);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "&New";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Location = new System.Drawing.Point(236, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(4, 240);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(4, 240);
            // 
            // Users
            // 
            this.Users.Dock = System.Windows.Forms.DockStyle.Top;
            this.Users.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.Users.Location = new System.Drawing.Point(0, 4);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(240, 20);
            this.Users.Text = "Users:";
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(0, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 4);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 4);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.gridPasswords);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Users);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "ChangePassword";
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridTextBoxColumn colUsername;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn colPassword;
        private System.Windows.Forms.DataGridTextBoxColumn colRole;
        private System.Windows.Forms.DataGridTextBoxColumn colUserId;
        private System.Windows.Forms.DataGrid gridPasswords;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Users;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}