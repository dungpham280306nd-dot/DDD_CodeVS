using System.Windows.Forms;

namespace StoreXManagerApp
{
    partial class frmOrderHistory
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cboCustomerFilter = new System.Windows.Forms.ComboBox();
            this.lblCustomerFilter = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.lblOrderDetails = new System.Windows.Forms.Label();
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.grpFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFilters
            // 
            this.grpFilters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpFilters.Controls.Add(this.btnClearFilter);
            this.grpFilters.Controls.Add(this.btnFilter);
            this.grpFilters.Controls.Add(this.cboCustomerFilter);
            this.grpFilters.Controls.Add(this.lblCustomerFilter);
            this.grpFilters.Controls.Add(this.dtpToDate);
            this.grpFilters.Controls.Add(this.lblToDate);
            this.grpFilters.Controls.Add(this.dtpFromDate);
            this.grpFilters.Controls.Add(this.lblFromDate);
            this.grpFilters.Location = new System.Drawing.Point(12, 12);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(858, 100);
            this.grpFilters.TabIndex = 0;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Bộ lọc";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.Location = new System.Drawing.Point(753, 58);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(99, 28);
            this.btnClearFilter.TabIndex = 7;
            this.btnClearFilter.Text = "Xóa bộ lọc";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(753, 22);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(99, 28);
            this.btnFilter.TabIndex = 6;
            this.btnFilter.Text = "Lọc";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // cboCustomerFilter
            // 
            this.cboCustomerFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerFilter.FormattingEnabled = true;
            this.cboCustomerFilter.Location = new System.Drawing.Point(448, 25);
            this.cboCustomerFilter.Name = "cboCustomerFilter";
            this.cboCustomerFilter.Size = new System.Drawing.Size(278, 23);
            this.cboCustomerFilter.TabIndex = 5;
            // 
            // lblCustomerFilter
            // 
            this.lblCustomerFilter.AutoSize = true;
            this.lblCustomerFilter.Location = new System.Drawing.Point(317, 28);
            this.lblCustomerFilter.Name = "lblCustomerFilter";
            this.lblCustomerFilter.Size = new System.Drawing.Size(125, 15);
            this.lblCustomerFilter.TabIndex = 4;
            this.lblCustomerFilter.Text = "Lọc theo khách hàng:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(76, 61);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 23);
            this.dtpToDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(11, 67);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(59, 15);
            this.lblToDate.TabIndex = 2;
            this.lblToDate.Text = "Đến ngày:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(76, 25);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 23);
            this.dtpFromDate.TabIndex = 1;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(17, 31);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(53, 15);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Từ ngày:";
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrders.Location = new System.Drawing.Point(12, 126);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(138, 17);
            this.lblOrders.TabIndex = 1;
            this.lblOrders.Text = "Danh sách đơn hàng";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Location = new System.Drawing.Point(12, 146);
            this.dgvOrders.MultiSelect = false;
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.RowTemplate.Height = 25;
            this.dgvOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrders.Size = new System.Drawing.Size(858, 222);
            this.dgvOrders.TabIndex = 2;
            this.dgvOrders.SelectionChanged += new System.EventHandler(this.dgvOrders_SelectionChanged);
            // 
            // lblOrderDetails
            // 
            this.lblOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrderDetails.AutoSize = true;
            this.lblOrderDetails.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblOrderDetails.Location = new System.Drawing.Point(12, 381);
            this.lblOrderDetails.Name = "lblOrderDetails";
            this.lblOrderDetails.Size = new System.Drawing.Size(127, 17);
            this.lblOrderDetails.TabIndex = 3;
            this.lblOrderDetails.Text = "Chi tiết đơn hàng: ";
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.AllowUserToAddRows = false;
            this.dgvOrderDetails.AllowUserToDeleteRows = false;
            this.dgvOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOrderDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(12, 401);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.ReadOnly = true;
            this.dgvOrderDetails.RowTemplate.Height = 25;
            this.dgvOrderDetails.Size = new System.Drawing.Size(858, 178);
            this.dgvOrderDetails.TabIndex = 4;
            // 
            // frmOrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 591);
            this.Controls.Add(this.dgvOrderDetails);
            this.Controls.Add(this.lblOrderDetails);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.grpFilters);
            this.Name = "frmOrderHistory";
            this.Text = "Lịch sử Đơn hàng";
            this.Load += new System.EventHandler(this.frmOrderHistory_Load);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private GroupBox grpFilters;
        private DateTimePicker dtpToDate;
        private Label lblToDate;
        private DateTimePicker dtpFromDate;
        private Label lblFromDate;
        private Button btnClearFilter;
        private Button btnFilter;
        private ComboBox cboCustomerFilter;
        private Label lblCustomerFilter;
        private Label lblOrders;
        private DataGridView dgvOrders;
        private Label lblOrderDetails;
        private DataGridView dgvOrderDetails;
    }
}