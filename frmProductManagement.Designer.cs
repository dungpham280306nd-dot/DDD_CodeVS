using System.Windows.Forms;

namespace StoreXManagerApp
{
    partial class frmProductManagement
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.grpProductDetails = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.chkIsDiscontinued = new System.Windows.Forms.CheckBox();
            this.numStock = new System.Windows.Forms.NumericUpDown();
            this.lblStock = new System.Windows.Forms.Label();
            this.numUnitCost = new System.Windows.Forms.NumericUpDown();
            this.lblUnitCost = new System.Windows.Forms.Label();
            this.numUnitPrice = new System.Windows.Forms.NumericUpDown();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.lblProductID = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.grpProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(12, 41);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(568, 447);
            this.dgvProducts.TabIndex = 2;
            this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
            // 
            // grpProductDetails
            // 
            this.grpProductDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProductDetails.Controls.Add(this.btnDelete);
            this.grpProductDetails.Controls.Add(this.btnSave);
            this.grpProductDetails.Controls.Add(this.btnAddNew);
            this.grpProductDetails.Controls.Add(this.chkIsDiscontinued);
            this.grpProductDetails.Controls.Add(this.numStock);
            this.grpProductDetails.Controls.Add(this.lblStock);
            this.grpProductDetails.Controls.Add(this.numUnitCost);
            this.grpProductDetails.Controls.Add(this.lblUnitCost);
            this.grpProductDetails.Controls.Add(this.numUnitPrice);
            this.grpProductDetails.Controls.Add(this.lblUnitPrice);
            this.grpProductDetails.Controls.Add(this.cboSupplier);
            this.grpProductDetails.Controls.Add(this.lblSupplier);
            this.grpProductDetails.Controls.Add(this.cboCategory);
            this.grpProductDetails.Controls.Add(this.lblCategory);
            this.grpProductDetails.Controls.Add(this.txtProductName);
            this.grpProductDetails.Controls.Add(this.lblProductName);
            this.grpProductDetails.Controls.Add(this.txtProductID);
            this.grpProductDetails.Controls.Add(this.lblProductID);
            this.grpProductDetails.Location = new System.Drawing.Point(586, 12);
            this.grpProductDetails.Name = "grpProductDetails";
            this.grpProductDetails.Size = new System.Drawing.Size(314, 476);
            this.grpProductDetails.TabIndex = 3;
            this.grpProductDetails.TabStop = false;
            this.grpProductDetails.Text = "Thông tin chi tiết";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Location = new System.Drawing.Point(212, 381);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 33);
            this.btnDelete.TabIndex = 17;
            this.btnDelete.Text = "Xóa (Ngừng KD)";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGreen;
            this.btnSave.Location = new System.Drawing.Point(110, 381);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 33);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Lưu Thay Đổi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(8, 381);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(96, 33);
            this.btnAddNew.TabIndex = 15;
            this.btnAddNew.Text = "Thêm Mới";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // chkIsDiscontinued
            // 
            this.chkIsDiscontinued.AutoSize = true;
            this.chkIsDiscontinued.Location = new System.Drawing.Point(109, 309);
            this.chkIsDiscontinued.Name = "chkIsDiscontinued";
            this.chkIsDiscontinued.Size = new System.Drawing.Size(122, 19);
            this.chkIsDiscontinued.TabIndex = 14;
            this.chkIsDiscontinued.Text = "Ngừng kinh doanh";
            this.chkIsDiscontinued.UseVisualStyleBackColor = true;
            // 
            // numStock
            // 
            this.numStock.Location = new System.Drawing.Point(109, 269);
            this.numStock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numStock.Name = "numStock";
            this.numStock.Size = new System.Drawing.Size(199, 23);
            this.numStock.TabIndex = 13;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(8, 271);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(53, 15);
            this.lblStock.TabIndex = 12;
            this.lblStock.Text = "Tồn kho:";
            // 
            // numUnitCost
            // 
            this.numUnitCost.DecimalPlaces = 2;
            this.numUnitCost.Location = new System.Drawing.Point(109, 229);
            this.numUnitCost.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numUnitCost.Name = "numUnitCost";
            this.numUnitCost.Size = new System.Drawing.Size(199, 23);
            this.numUnitCost.TabIndex = 11;
            // 
            // lblUnitCost
            // 
            this.lblUnitCost.AutoSize = true;
            this.lblUnitCost.Location = new System.Drawing.Point(8, 231);
            this.lblUnitCost.Name = "lblUnitCost";
            this.lblUnitCost.Size = new System.Drawing.Size(51, 15);
            this.lblUnitCost.TabIndex = 10;
            this.lblUnitCost.Text = "Giá vốn:";
            // 
            // numUnitPrice
            // 
            this.numUnitPrice.DecimalPlaces = 2;
            this.numUnitPrice.Location = new System.Drawing.Point(109, 189);
            this.numUnitPrice.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numUnitPrice.Name = "numUnitPrice";
            this.numUnitPrice.Size = new System.Drawing.Size(199, 23);
            this.numUnitPrice.TabIndex = 9;
            // 
            // lblUnitPrice
            // 
            this.lblUnitPrice.AutoSize = true;
            this.lblUnitPrice.Location = new System.Drawing.Point(8, 191);
            this.lblUnitPrice.Name = "lblUnitPrice";
            this.lblUnitPrice.Size = new System.Drawing.Size(51, 15);
            this.lblUnitPrice.TabIndex = 8;
            this.lblUnitPrice.Text = "Giá bán:";
            // 
            // cboSupplier
            // 
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(109, 149);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(199, 23);
            this.cboSupplier.TabIndex = 7;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(8, 152);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(84, 15);
            this.lblSupplier.TabIndex = 6;
            this.lblSupplier.Text = "Nhà cung cấp:";
            // 
            // cboCategory
            // 
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(109, 109);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(199, 23);
            this.cboCategory.TabIndex = 5;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(8, 112);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(65, 15);
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Danh mục:";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(109, 69);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(199, 23);
            this.txtProductName.TabIndex = 3;
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(8, 72);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(87, 15);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên sản phẩm:";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(109, 29);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.ReadOnly = true;
            this.txtProductID.Size = new System.Drawing.Size(199, 23);
            this.txtProductID.TabIndex = 1;
            // 
            // lblProductID
            // 
            this.lblProductID.AutoSize = true;
            this.lblProductID.Location = new System.Drawing.Point(8, 32);
            this.lblProductID.Name = "lblProductID";
            this.lblProductID.Size = new System.Drawing.Size(43, 15);
            this.lblProductID.TabIndex = 0;
            this.lblProductID.Text = "Mã SP:";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 15);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(59, 15);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Tìm kiếm:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(77, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(422, 23);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(505, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 500);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.grpProductDetails);
            this.Controls.Add(this.dgvProducts);
            this.Name = "frmProductManagement";
            this.Text = "Quản lý Sản phẩm";
            this.Load += new System.EventHandler(this.frmProductManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.grpProductDetails.ResumeLayout(false);
            this.grpProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvProducts;
        private GroupBox grpProductDetails;
        private TextBox txtProductID;
        private Label lblProductID;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private TextBox txtProductName;
        private Label lblProductName;
        private ComboBox cboCategory;
        private Label lblCategory;
        private ComboBox cboSupplier;
        private Label lblSupplier;
        private NumericUpDown numUnitPrice;
        private Label lblUnitPrice;
        private NumericUpDown numUnitCost;
        private Label lblUnitCost;
        private NumericUpDown numStock;
        private Label lblStock;
        private CheckBox chkIsDiscontinued;
        private Button btnDelete;
        private Button btnSave;
        private Button btnAddNew;
    }
}