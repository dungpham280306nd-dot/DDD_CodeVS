using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreXManagerApp.BLL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp
{
    public partial class frmProductManagement : Form
    {
        // Khai báo các đối tượng BLL để tái sử dụng trong toàn bộ Form
        private readonly ProductBLL _productBLL;
        private readonly CategoryBLL _categoryBLL;
        private readonly SupplierBLL _supplierBLL;

        private readonly string _currentUserRole;

        public frmProductManagement(string currentUserRole)
        {
            InitializeComponent();
            _productBLL = new ProductBLL();
            _categoryBLL = new CategoryBLL();
            _supplierBLL = new SupplierBLL();
            _currentUserRole = currentUserRole;
        }

        private void AuthorizeControls()
        {
            // Nếu người dùng không phải là Admin, vô hiệu hóa tất cả các nút chức năng
            if (_currentUserRole != "Admin" && _currentUserRole != "Warehouse")
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnAddNew.Enabled = false;

                txtProductName.ReadOnly = true;
                cboCategory.Enabled = false;
                cboSupplier.Enabled = false;
                numUnitPrice.ReadOnly = true;
                numUnitCost.ReadOnly = true;
                numStock.ReadOnly = true;
                chkIsDiscontinued.Enabled = false;
            }
        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadComboBoxData();
            ClearForm();
            AuthorizeControls();
        }

        #region Data Loading Methods (Đã được tái cấu trúc)

        private void LoadProducts(string searchTerm = "")
        {
            try
            {
                // Form chỉ cần gọi BLL để lấy dữ liệu, không cần biết câu SQL là gì.
                dgvProducts.DataSource = _productBLL.GetProductDetailsForManagement(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Sửa lỗi: Sử dụng đối tượng BLL đã được khởi tạo
                cboCategory.DataSource = _categoryBLL.GetAllCategories();
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                cboSupplier.DataSource = _supplierBLL.GetAllSuppliers();
                cboSupplier.DisplayMember = "SupplierName";
                cboSupplier.ValueMember = "SupplierID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region UI Event Handlers

        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProducts.SelectedRows[0];
                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                cboCategory.Text = row.Cells["CategoryName"].Value?.ToString() ?? "";
                cboSupplier.Text = row.Cells["SupplierName"].Value?.ToString() ?? "";
                numUnitPrice.Value = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                numUnitCost.Value = Convert.ToDecimal(row.Cells["UnitCost"].Value);
                numStock.Value = Convert.ToInt32(row.Cells["Stock"].Value);
                chkIsDiscontinued.Checked = Convert.ToBoolean(row.Cells["IsDiscontinued"].Value);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadProducts(txtSearch.Text.Trim());
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Đóng gói dữ liệu từ Form vào đối tượng DTO để truyền đi
            ProductDTO product = new ProductDTO
            {
                ProductName = txtProductName.Text.Trim(),
                CategoryID = (cboCategory.SelectedValue != null && cboCategory.SelectedValue != DBNull.Value) ? (int?)Convert.ToInt32(cboCategory.SelectedValue) : null,
                SupplierID = (cboSupplier.SelectedValue != null && cboSupplier.SelectedValue != DBNull.Value) ? (int?)Convert.ToInt32(cboSupplier.SelectedValue) : null,
                UnitPrice = numUnitPrice.Value,
                UnitCost = numUnitCost.Value,
                Stock = (int)numStock.Value,
                IsDiscontinued = chkIsDiscontinued.Checked
            };

            bool success = false;
            string message = "";
            try
            {
                if (string.IsNullOrEmpty(txtProductID.Text)) // Thêm mới
                {
                    success = _productBLL.InsertProduct(product);
                    message = success ? "Thêm sản phẩm thành công!" : "Thêm sản phẩm thất bại.";
                }
                else // Cập nhật
                {
                    product.ProductID = Convert.ToInt32(txtProductID.Text);
                    success = _productBLL.UpdateProduct(product);
                    message = success ? "Cập nhật sản phẩm thành công!" : "Cập nhật sản phẩm thất bại.";
                }

                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (success)
                {
                    LoadProducts(); // Tải lại lưới nếu thành công
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn ngừng kinh doanh sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int productId = Convert.ToInt32(txtProductID.Text);
                    bool success = _productBLL.SoftDeleteProduct(productId);
                    if (success)
                    {
                        MessageBox.Show("Đã ngừng kinh doanh sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadProducts();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Thao tác thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Helper Methods

        private void ClearForm()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            cboCategory.SelectedIndex = -1;
            cboSupplier.SelectedIndex = -1;
            numUnitPrice.Value = 0;
            numUnitCost.Value = 0;
            numStock.Value = 0;
            chkIsDiscontinued.Checked = false;
            txtProductName.Focus();
        }

        #endregion
    }
}