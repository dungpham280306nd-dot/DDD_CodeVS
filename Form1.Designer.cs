// Dán toàn bộ code này vào file Form1.Designer.cs
namespace StoreXManagerApp
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýKháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nghiệpVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửĐơnHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.báoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bảngĐiềuKhiểnDashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSalesControls = new System.Windows.Forms.GroupBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.btnRemoveFromCart = new System.Windows.Forms.Button();
            this.txtProductSearch = new System.Windows.Forms.TextBox();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.btnCreateOrder = new System.Windows.Forms.Button();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.btnAddToCart = new System.Windows.Forms.Button();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.lblProducts = new System.Windows.Forms.Label();
            this.cboEmployees = new System.Windows.Forms.ComboBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cboCustomers = new System.Windows.Forms.ComboBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblNotification = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.grpSalesControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.quảnLýToolStripMenuItem,
            this.nghiệpVụToolStripMenuItem,
            this.báoCáoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.toolStripSeparator1,
            this.thoátToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng &xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.thoátToolStripMenuItem.Text = "&Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // quảnLýToolStripMenuItem
            // 
            this.quảnLýToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLýSảnPhẩmToolStripMenuItem,
            this.quảnLýKháchHàngToolStripMenuItem,
            this.quảnLýNhânViênToolStripMenuItem});
            this.quảnLýToolStripMenuItem.Name = "quảnLýToolStripMenuItem";
            this.quảnLýToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.quảnLýToolStripMenuItem.Text = "Quản lý";
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý Sản phẩm";
            this.quảnLýSảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.quảnLýSảnPhẩmToolStripMenuItem_Click);
            // 
            // quảnLýKháchHàngToolStripMenuItem
            // 
            this.quảnLýKháchHàngToolStripMenuItem.Name = "quảnLýKháchHàngToolStripMenuItem";
            this.quảnLýKháchHàngToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quảnLýKháchHàngToolStripMenuItem.Text = "Quản lý Khách hàng";
            this.quảnLýKháchHàngToolStripMenuItem.Click += new System.EventHandler(this.quảnLýKháchHàngToolStripMenuItem_Click);
            // 
            // quảnLýNhânViênToolStripMenuItem
            // 
            this.quảnLýNhânViênToolStripMenuItem.Name = "quảnLýNhânViênToolStripMenuItem";
            this.quảnLýNhânViênToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.quảnLýNhânViênToolStripMenuItem.Text = "Quản lý Nhân viên";
            this.quảnLýNhânViênToolStripMenuItem.Click += new System.EventHandler(this.quảnLýNhânViênToolStripMenuItem_Click);
            // 
            // nghiệpVụToolStripMenuItem
            // 
            this.nghiệpVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lịchSửĐơnHàngToolStripMenuItem});
            this.nghiệpVụToolStripMenuItem.Name = "nghiệpVụToolStripMenuItem";
            this.nghiệpVụToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.nghiệpVụToolStripMenuItem.Text = "Nghiệp vụ";
            // 
            // lịchSửĐơnHàngToolStripMenuItem
            // 
            this.lịchSửĐơnHàngToolStripMenuItem.Name = "lịchSửĐơnHàngToolStripMenuItem";
            this.lịchSửĐơnHàngToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.lịchSửĐơnHàngToolStripMenuItem.Text = "Lịch sử đơn hàng";
            this.lịchSửĐơnHàngToolStripMenuItem.Click += new System.EventHandler(this.lịchSửĐơnHàngToolStripMenuItem_Click);
            // 
            // báoCáoToolStripMenuItem
            // 
            this.báoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bảngĐiềuKhiểnDashboardToolStripMenuItem});
            this.báoCáoToolStripMenuItem.Name = "báoCáoToolStripMenuItem";
            this.báoCáoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.báoCáoToolStripMenuItem.Text = "Báo cáo";
            // 
            // bảngĐiềuKhiểnDashboardToolStripMenuItem
            // 
            this.bảngĐiềuKhiểnDashboardToolStripMenuItem.Name = "bảngĐiềuKhiểnDashboardToolStripMenuItem";
            this.bảngĐiềuKhiểnDashboardToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.bảngĐiềuKhiểnDashboardToolStripMenuItem.Text = "Bảng điều khiển (Dashboard)";
            this.bảngĐiềuKhiểnDashboardToolStripMenuItem.Click += new System.EventHandler(this.bảngĐiềuKhiểnDashboardToolStripMenuItem_Click);
            // 
            // grpSalesControls
            // 
            this.grpSalesControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSalesControls.Controls.Add(this.lblTotalAmount);
            this.grpSalesControls.Controls.Add(this.btnRemoveFromCart);
            this.grpSalesControls.Controls.Add(this.txtProductSearch);
            this.grpSalesControls.Controls.Add(this.lblProductSearch);
            this.grpSalesControls.Controls.Add(this.lblCart);
            this.grpSalesControls.Controls.Add(this.btnCreateOrder);
            this.grpSalesControls.Controls.Add(this.dgvCart);
            this.grpSalesControls.Controls.Add(this.btnAddToCart);
            this.grpSalesControls.Controls.Add(this.numQuantity);
            this.grpSalesControls.Controls.Add(this.lblQuantity);
            this.grpSalesControls.Controls.Add(this.dgvProducts);
            this.grpSalesControls.Controls.Add(this.lblProducts);
            this.grpSalesControls.Controls.Add(this.cboEmployees);
            this.grpSalesControls.Controls.Add(this.lblEmployee);
            this.grpSalesControls.Controls.Add(this.cboCustomers);
            this.grpSalesControls.Controls.Add(this.lblCustomer);
            this.grpSalesControls.Location = new System.Drawing.Point(12, 53);
            this.grpSalesControls.Name = "grpSalesControls";
            this.grpSalesControls.Size = new System.Drawing.Size(791, 549);
            this.grpSalesControls.TabIndex = 1;
            this.grpSalesControls.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblTotalAmount.Location = new System.Drawing.Point(338, 504);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(279, 28);
            this.lblTotalAmount.TabIndex = 16;
            this.lblTotalAmount.Text = "Tổng tiền: 0 VND";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRemoveFromCart
            // 
            this.btnRemoveFromCart.BackColor = System.Drawing.Color.MistyRose;
            this.btnRemoveFromCart.Location = new System.Drawing.Point(113, 311);
            this.btnRemoveFromCart.Name = "btnRemoveFromCart";
            this.btnRemoveFromCart.Size = new System.Drawing.Size(111, 25);
            this.btnRemoveFromCart.TabIndex = 8;
            this.btnRemoveFromCart.Text = "Xóa khỏi giỏ";
            this.btnRemoveFromCart.UseVisualStyleBackColor = false;
            this.btnRemoveFromCart.Click += new System.EventHandler(this.btnRemoveFromCart_Click);
            // 
            // txtProductSearch
            // 
            this.txtProductSearch.Location = new System.Drawing.Point(101, 84);
            this.txtProductSearch.Name = "txtProductSearch";
            this.txtProductSearch.Size = new System.Drawing.Size(359, 23);
            this.txtProductSearch.TabIndex = 4;
            this.txtProductSearch.TextChanged += new System.EventHandler(this.txtProductSearch_TextChanged);
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.AutoSize = true;
            this.lblProductSearch.Location = new System.Drawing.Point(6, 87);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(89, 15);
            this.lblProductSearch.TabIndex = 13;
            this.lblProductSearch.Text = "Tìm sản phẩm:";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCart.Location = new System.Drawing.Point(6, 319);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(68, 17);
            this.lblCart.TabIndex = 11;
            this.lblCart.Text = "Giỏ Hàng";
            // 
            // btnCreateOrder
            // 
            this.btnCreateOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateOrder.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCreateOrder.ForeColor = System.Drawing.Color.White;
            this.btnCreateOrder.Location = new System.Drawing.Point(623, 497);
            this.btnCreateOrder.Name = "btnCreateOrder";
            this.btnCreateOrder.Size = new System.Drawing.Size(150, 42);
            this.btnCreateOrder.TabIndex = 10;
            this.btnCreateOrder.Text = "Tạo Đơn Hàng";
            this.btnCreateOrder.UseVisualStyleBackColor = false;
            this.btnCreateOrder.Click += new System.EventHandler(this.btnCreateOrder_Click);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(6, 339);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowTemplate.Height = 25;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(767, 152);
            this.dgvCart.TabIndex = 9;
            // 
            // btnAddToCart
            // 
            this.btnAddToCart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddToCart.Location = new System.Drawing.Point(159, 277);
            this.btnAddToCart.Name = "btnAddToCart";
            this.btnAddToCart.Size = new System.Drawing.Size(170, 31);
            this.btnAddToCart.TabIndex = 7;
            this.btnAddToCart.Text = "Thêm vào giỏ hàng";
            this.btnAddToCart.UseVisualStyleBackColor = true;
            this.btnAddToCart.Click += new System.EventHandler(this.btnAddToCart_Click);
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(69, 281);
            this.numQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(75, 23);
            this.numQuantity.TabIndex = 6;
            this.numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(6, 283);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(57, 15);
            this.lblQuantity.TabIndex = 6;
            this.lblQuantity.Text = "Số lượng:";
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(6, 113);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 25;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(767, 158);
            this.dgvProducts.TabIndex = 5;
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblProducts.Location = new System.Drawing.Point(6, 61);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(138, 17);
            this.lblProducts.TabIndex = 4;
            this.lblProducts.Text = "Danh sách sản phẩm";
            // 
            // cboEmployees
            // 
            this.cboEmployees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployees.FormattingEnabled = true;
            this.cboEmployees.Location = new System.Drawing.Point(525, 16);
            this.cboEmployees.Name = "cboEmployees";
            this.cboEmployees.Size = new System.Drawing.Size(248, 23);
            this.cboEmployees.TabIndex = 3;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(397, 19);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(122, 15);
            this.lblEmployee.TabIndex = 2;
            this.lblEmployee.Text = "Nhân viên bán hàng:";
            // 
            // cboCustomers
            // 
            this.cboCustomers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomers.FormattingEnabled = true;
            this.cboCustomers.Location = new System.Drawing.Point(121, 16);
            this.cboCustomers.Name = "cboCustomers";
            this.cboCustomers.Size = new System.Drawing.Size(248, 23);
            this.cboCustomers.TabIndex = 2;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(109, 15);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "Chọn khách hàng:";
            // 
            // lblNotification
            // 
            this.lblNotification.AutoSize = true;
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblNotification.ForeColor = System.Drawing.Color.Red;
            this.lblNotification.Location = new System.Drawing.Point(230, 30);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(121, 17);
            this.lblNotification.TabIndex = 14;
            this.lblNotification.Text = "Notification Label";
            this.lblNotification.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 614);
            this.Controls.Add(this.lblNotification);
            this.Controls.Add(this.grpSalesControls);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Quản lý Bán hàng - StoreX";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpSalesControls.ResumeLayout(false);
            this.grpSalesControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýKháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýNhânViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nghiệpVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửĐơnHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem báoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bảngĐiềuKhiểnDashboardToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpSalesControls;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Button btnRemoveFromCart;
        private System.Windows.Forms.TextBox txtProductSearch;
        private System.Windows.Forms.Label lblProductSearch;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Button btnCreateOrder;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Button btnAddToCart;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.ComboBox cboEmployees;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cboCustomers;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblNotification;
    }
}



