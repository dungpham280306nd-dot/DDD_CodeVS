using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoreXManager.BLL;
using StoreXManagerApp.BLL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp.DTO
{
    public partial class frmEmployeeManagement : Form
    {
        // Form chỉ cần biết đến các lớp BLL
        private readonly EmployeeBLL _employeeBLL;
        private readonly RoleBLL _roleBLL;

        public frmEmployeeManagement()
        {
            InitializeComponent();
            _employeeBLL = new EmployeeBLL();
            _roleBLL = new RoleBLL();
        }

        private void frmEmployeeManagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadRoles();
            ClearForm();
        }

        #region Data Loading & UI

        private void LoadEmployees()
        {
            try
            {
                // Giao diện chỉ gọi BLL, không còn biết gì về SQL
                dgvEmployees.DataSource = _employeeBLL.GetEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            try
            {
                // Giao diện gọi BLL để tải danh sách vai trò
                cboRole.DataSource = _roleBLL.GetAllRoles();
                cboRole.DisplayMember = "RoleName";
                cboRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                cboRole.Text = row.Cells["RoleName"].Value.ToString();
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                txtPassword.Clear();
                lblPassword.Text = "Mật khẩu (để trống nếu không đổi):";
            }
        }

        private void ClearForm()
        {
            txtEmployeeID.Clear();
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            cboRole.SelectedIndex = -1;
            chkIsActive.Checked = true;
            lblPassword.Text = "Mật khẩu:";
            txtFullName.Focus();
        }
        #endregion

        #region Button Events

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Bước 1: Đóng gói dữ liệu từ Form vào đối tượng DTO
                EmployeeDTO employee = new EmployeeDTO
                {
                    FullName = txtFullName.Text.Trim(),
                    Username = txtUsername.Text.Trim(),
                    Password = txtPassword.Text, // Gửi chuỗi thô, BLL sẽ hash
                    RoleID = Convert.ToInt32(cboRole.SelectedValue),
                    IsActive = chkIsActive.Checked
                };

                bool success;
                // Bước 2: Gọi đến lớp BLL để xử lý nghiệp vụ và lưu dữ liệu
                if (string.IsNullOrEmpty(txtEmployeeID.Text)) // Thêm mới
                {
                    success = _employeeBLL.InsertEmployee(employee);
                    if (success)
                    {
                        MessageBox.Show("Thêm nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else // Cập nhật
                {
                    employee.EmployeeID = Convert.ToInt32(txtEmployeeID.Text);
                    success = _employeeBLL.UpdateEmployee(employee);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Bước 3: Cập nhật lại giao diện nếu thành công
                if (success)
                {
                    LoadEmployees();
                    ClearForm();
                }
            }
            catch (SqlException ex) when (ex.Number == 2627) // Bắt lỗi trùng lặp từ DAL
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại. Vui lòng chọn tên khác.", "Lỗi trùng lặp", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) // Bắt lỗi nghiệp vụ từ BLL (ví dụ: thiếu thông tin)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn vô hiệu hóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    int employeeId = Convert.ToInt32(txtEmployeeID.Text);
                    bool success = _employeeBLL.DeleteEmployee(employeeId);

                    if (success)
                    {
                        MessageBox.Show("Vô hiệu hóa nhân viên thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployees();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Thao tác thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}
