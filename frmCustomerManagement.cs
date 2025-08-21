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
using StoreXManager.BLL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp
{
    public partial class frmCustomerManagement : Form
    {
        // Form chỉ cần biết đến lớp BLL
        private readonly CustomerBLL _customerBLL;
        private readonly string _currentUserRole;

        public frmCustomerManagement(string userRole)
        {
            InitializeComponent();
            _customerBLL = new CustomerBLL();
            _currentUserRole = userRole;
        }
        private void AuthorizeControls()
        {
            if (_currentUserRole != "Admin")
            {
                btnSave.Enabled = false;
                btnDelete.Enabled = false;
                btnAddNew.Enabled = false;

                txtCustomerName.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtPhone.ReadOnly = true;
                txtEmail.ReadOnly = true;
            }
        }

        private void frmCustomerManagement_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            ClearForm();
            AuthorizeControls();
        }

        #region Data Loading & UI Events (Lớp Giao diện)

        private void LoadCustomers(string searchTerm = "")
        {
            try
            {
                // Giao diện chỉ gọi BLL, không còn biết gì về SQL
                dgvCustomers.DataSource = _customerBLL.GetCustomers(searchTerm);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer list: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCustomers.SelectedRows[0];
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadCustomers(txtSearch.Text.Trim());
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Đóng gói dữ liệu từ Form vào đối tượng DTO
                CustomerDTO customer = new CustomerDTO
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                bool success;
                // Bước 2: Gọi đến lớp BLL để xử lý
                if (string.IsNullOrEmpty(txtCustomerID.Text)) // Thêm mới
                {
                    success = _customerBLL.InsertCustomer(customer);
                    if (success)
                    {
                        MessageBox.Show("Customer added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Cập nhật
                {
                    customer.CustomerID = Convert.ToInt32(txtCustomerID.Text);
                    success = _customerBLL.UpdateCustomer(customer);
                    if (success)
                    {
                        MessageBox.Show("Customer information updated successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Bước 3: Cập nhật lại giao diện nếu thành công
                if (success)
                {
                    LoadCustomers();
                    ClearForm();
                }
            }
            catch (SqlException ex) when (ex.Number == 2627) // Bắt lỗi trùng lặp từ DAL
            {
                MessageBox.Show("Phone Number or Email already exists. Please check again.", "Duplicate error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Bắt lỗi nghiệp vụ từ BLL
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer to delete.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer? This action cannot be undone.", "Confirm deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int customerId = Convert.ToInt32(txtCustomerID.Text);
                    if (_customerBLL.DeleteCustomer(customerId))
                    {
                        MessageBox.Show("Customer deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers();
                        ClearForm();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Helper Methods
        private void ClearForm()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtCustomerName.Focus();
        }
        #endregion

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
