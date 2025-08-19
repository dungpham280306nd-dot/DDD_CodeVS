// Dán toàn bộ code này vào file frmEmployeeManagement.Designer.cs
namespace StoreXManagerApp.DTO
{
    partial class frmEmployeeManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.grpEmployeeDetails = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.lblEmployeeID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.grpEmployeeDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AllowUserToDeleteRows = false;
            this.dgvEmployees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Location = new System.Drawing.Point(12, 12);
            this.dgvEmployees.MultiSelect = false;
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.ReadOnly = true;
            this.dgvEmployees.RowTemplate.Height = 25;
            this.dgvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployees.Size = new System.Drawing.Size(538, 386);
            this.dgvEmployees.TabIndex = 10;
            this.dgvEmployees.SelectionChanged += new System.EventHandler(this.dgvEmployees_SelectionChanged);
            // 
            // grpEmployeeDetails
            // 
            this.grpEmployeeDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmployeeDetails.Controls.Add(this.btnDelete);
            this.grpEmployeeDetails.Controls.Add(this.btnSave);
            this.grpEmployeeDetails.Controls.Add(this.btnAddNew);
            this.grpEmployeeDetails.Controls.Add(this.chkIsActive);
            this.grpEmployeeDetails.Controls.Add(this.cboRole);
            this.grpEmployeeDetails.Controls.Add(this.lblRole);
            this.grpEmployeeDetails.Controls.Add(this.txtPassword);
            this.grpEmployeeDetails.Controls.Add(this.lblPassword);
            this.grpEmployeeDetails.Controls.Add(this.txtUsername);
            this.grpEmployeeDetails.Controls.Add(this.lblUsername);
            this.grpEmployeeDetails.Controls.Add(this.txtFullName);
            this.grpEmployeeDetails.Controls.Add(this.lblFullName);
            this.grpEmployeeDetails.Controls.Add(this.txtEmployeeID);
            this.grpEmployeeDetails.Controls.Add(this.lblEmployeeID);
            this.grpEmployeeDetails.Location = new System.Drawing.Point(556, 12);
            this.grpEmployeeDetails.Name = "grpEmployeeDetails";
            this.grpEmployeeDetails.Size = new System.Drawing.Size(314, 386);
            this.grpEmployeeDetails.TabIndex = 11;
            this.grpEmployeeDetails.TabStop = false;
            this.grpEmployeeDetails.Text = "Thông tin nhân viên";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Location = new System.Drawing.Point(212, 280);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 33);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa (Vô hiệu hóa)";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Location = new System.Drawing.Point(110, 280);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu Thay Đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(9, 280);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(96, 33);
            this.btnAddNew.TabIndex = 5;
            this.btnAddNew.Text = "Thêm Mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(109, 239);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(111, 19);
            this.chkIsActive.TabIndex = 4;
            this.chkIsActive.Text = "Đang hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(109, 199);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(199, 23);
            this.cboRole.TabIndex = 3;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(9, 202);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(44, 15);
            this.lblRole.TabIndex = 8;
            this.lblRole.Text = "Vai trò:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(109, 159);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(199, 23);
            this.txtPassword.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 162);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(60, 15);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Mật khẩu:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(109, 119);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(199, 23);
            this.txtUsername.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(9, 122);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(90, 15);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Tên đăng nhập:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(109, 79);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(199, 23);
            this.txtFullName.TabIndex = 0;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(9, 82);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(61, 15);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ và tên:";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(109, 39);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.ReadOnly = true;
            this.txtEmployeeID.Size = new System.Drawing.Size(199, 23);
            this.txtEmployeeID.TabIndex = 10;
            // 
            // lblEmployeeID
            // 
            this.lblEmployeeID.AutoSize = true;
            this.lblEmployeeID.Location = new System.Drawing.Point(9, 42);
            this.lblEmployeeID.Name = "lblEmployeeID";
            this.lblEmployeeID.Size = new System.Drawing.Size(46, 15);
            this.lblEmployeeID.TabIndex = 0;
            this.lblEmployeeID.Text = "Mã NV:";
            // 
            // frmEmployeeManagement
            // 
            this.ClientSize = new System.Drawing.Size(882, 410);
            this.Controls.Add(this.grpEmployeeDetails);
            this.Controls.Add(this.dgvEmployees);
            this.Name = "frmEmployeeManagement";
            this.Text = "Quản lý Nhân viên";
            this.Load += new System.EventHandler(this.frmEmployeeManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.grpEmployeeDetails.ResumeLayout(false);
            this.grpEmployeeDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.GroupBox grpEmployeeDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.Label lblEmployeeID;
    }
}