using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreXManager.BLL;
using StoreXManagerApp.BLL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp
{
    public partial class Form1 : Form
    {
        private DataTable cartTable;
        private readonly CustomerBLL _customerBLL;
        private readonly EmployeeBLL _employeeBLL;
        private readonly ProductBLL _productBLL;
        private readonly OrderBLL _orderBLL;

        public Form1()
        {
            InitializeComponent();
            _customerBLL = new CustomerBLL();
            _employeeBLL = new EmployeeBLL();
            _productBLL = new ProductBLL();
            _orderBLL = new OrderBLL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupCartDataGridView();
            LoadAllData();
            ApplyAuthorization();
        }

        #region Data Loading & Authorization (đã được tái cấu trúc)

        private void ApplyAuthorization()
        {
            // Chào mừng người dùng ở thanh tiêu đề của Form
            this.Text = $"Quản lý Bán hàng - StoreX (Xin chào, {CurrentUser.FullName})";

            // --- BƯỚC 1: MẶC ĐỊNH ẨN TẤT CẢ CÁC MENU CẦN PHÂN QUYỀN ---
            quảnLýToolStripMenuItem.Visible = false;
            báoCáoToolStripMenuItem.Visible = false;

            // --- BƯỚC 2: HIỆN LẠI CÁC CHỨC NĂNG DỰA TRÊN VAI TRÒ ---
            if (CurrentUser.RoleName == "Admin")
            {
                // Admin có toàn quyền, hiện lại tất cả các menu đã ẩn
                quảnLýToolStripMenuItem.Visible = true;
                báoCáoToolStripMenuItem.Visible = true;
            }
            else if (CurrentUser.RoleName == "Sales")
            {
                // Sales được xem Quản lý và Báo cáo, nhưng với quyền hạn giới hạn

                quảnLýToolStripMenuItem.Visible = true; // Hiện menu "Quản lý"
                báoCáoToolStripMenuItem.Visible = true; // SỬA ĐỔI: Cho phép Sales xem Báo cáo

                // Ẩn các mục con trong menu "Quản lý" mà Sales không được phép xem
                quảnLýSảnPhẩmToolStripMenuItem.Visible = true;  // Cho phép xem Sản phẩm (chế độ chỉ đọc)
                quảnLýKháchHàngToolStripMenuItem.Visible = true; // Cho phép xem Khách hàng (chế độ chỉ đọc)
                quảnLýNhânViênToolStripMenuItem.Visible = false; // Vẫn ẩn quản lý nhân viên
            }
            else if (CurrentUser.RoleName == "Warehouse")
            {
                // Warehouse được quản lý sản phẩm và xem báo cáo
                quảnLýToolStripMenuItem.Visible = true;
                báoCáoToolStripMenuItem.Visible = true;

                // Ẩn các mục con không liên quan
                quảnLýSảnPhẩmToolStripMenuItem.Visible = true; // Được quản lý sản phẩm
                quảnLýKháchHàngToolStripMenuItem.Visible = false;
                quảnLýNhânViênToolStripMenuItem.Visible = false;

                // SỬA ĐỔI QUAN TRỌNG: Vô hiệu hóa chức năng bán hàng
                grpSalesControls.Enabled = false;
                // Có thể thêm một Label thông báo
                lblNotification.Text = "Chế độ Quản lý Kho. Chức năng bán hàng đã bị vô hiệu hóa.";
                lblNotification.Visible = true;
            }
        }

        private void LoadAllData()
        {
            LoadCustomers();
            LoadEmployees();
            LoadProducts();
        }

        private void LoadCustomers()
        {
            try
            {
                cboCustomers.DataSource = _customerBLL.GetCustomers();
                cboCustomers.DisplayMember = "CustomerName";
                cboCustomers.ValueMember = "CustomerID";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải khách hàng: " + ex.Message); }
        }

        private void LoadEmployees()
        {
            try
            {
                cboEmployees.DataSource = _employeeBLL.GetSalesEmployees();
                cboEmployees.DisplayMember = "FullName";
                cboEmployees.ValueMember = "EmployeeID";
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải nhân viên: " + ex.Message); }
        }

        private void LoadProducts(string searchTerm = "")
        {
            try
            {
                dgvProducts.DataSource = _productBLL.GetAvailableProducts(searchTerm);
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải sản phẩm: " + ex.Message); }
        }

        #endregion

        #region Cart Handling (Logic của Giao diện)

        private void SetupCartDataGridView()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ProductID", typeof(int));
            cartTable.Columns.Add("ProductName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("UnitPrice", typeof(decimal));
            cartTable.Columns.Add("LineTotal", typeof(decimal), "Quantity * UnitPrice");
            dgvCart.DataSource = cartTable;
            cartTable.RowChanged += (s, e) => UpdateTotalAmount();
            cartTable.RowDeleted += (s, e) => UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            decimal total = 0;
            if (cartTable.Rows.Count > 0 && cartTable.Compute("SUM(LineTotal)", string.Empty) != DBNull.Value)
            {
                total = Convert.ToDecimal(cartTable.Compute("SUM(LineTotal)", string.Empty));
            }
            lblTotalAmount.Text = $"Tổng tiền: {total:C0}";
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0) { /* ... */ return; }
            DataGridViewRow row = dgvProducts.SelectedRows[0];
            int stock = Convert.ToInt32(row.Cells["Stock"].Value);
            int quantityToAdd = (int)numQuantity.Value;
            if (quantityToAdd > stock) { MessageBox.Show("Hết hàng!"); return; }

            int productID = Convert.ToInt32(row.Cells["ProductID"].Value);
            DataRow existingRow = cartTable.Select($"ProductID = {productID}").FirstOrDefault();
            if (existingRow != null)
            {
                existingRow["Quantity"] = (int)existingRow["Quantity"] + quantityToAdd;
            }
            else
            {
                cartTable.Rows.Add(productID, row.Cells["ProductName"].Value, quantityToAdd, row.Cells["UnitPrice"].Value);
            }
            numQuantity.Value = 1;
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                cartTable.Rows.RemoveAt(dgvCart.SelectedRows[0].Index);
            }
        }

        private void txtProductSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(txtProductSearch.Text.Trim());
        }
        #endregion

        #region Order Creation (đã được tái cấu trúc)

        private void btnCreateOrder_Click(object sender, EventArgs e)
        {
            if (cboCustomers.SelectedValue == null || cboEmployees.SelectedValue == null || cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng điền đủ thông tin đơn hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OrderDTO newOrder = new OrderDTO
                {
                    CustomerID = Convert.ToInt32(cboCustomers.SelectedValue),
                    EmployeeID = Convert.ToInt32(cboEmployees.SelectedValue)
                };

                foreach (DataRow row in cartTable.Rows)
                {
                    newOrder.OrderItems.Add(new OrderDetailDTO
                    {
                        ProductID = Convert.ToInt32(row["ProductID"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        UnitPrice = Convert.ToDecimal(row["UnitPrice"])
                    });
                }

                int newOrderID = _orderBLL.CreateOrder(newOrder);

                MessageBox.Show($"Tạo đơn hàng thành công! Mã đơn hàng: {newOrderID}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cartTable.Clear();
                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo đơn hàng: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Menu Strip Event Handlers
        // Các hàm này giữ nguyên vì chúng là logic của giao diện

        // SỬA LỖI: THÊM CÁC HÀM XỬ LÝ SỰ KIỆN CÒN THIẾU
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
            this.Close();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmProductManagement productForm = new frmProductManagement(CurrentUser.RoleName))
            {
                productForm.ShowDialog();
            }
            LoadProducts();
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmCustomerManagement customerForm = new frmCustomerManagement(CurrentUser.RoleName))
            {
                customerForm.ShowDialog();
            }
            LoadCustomers();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new frmEmployeeManagement()) { form.ShowDialog(); }
            LoadEmployees();
        }

        private void lịchSửĐơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmOrderHistory().Show();
        }

        private void bảngĐiềuKhiểnDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDashboard().Show();
        }

        #endregion
    }
}