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

namespace StoreXManagerApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT e.EmployeeID, e.FullName, e.PasswordHash, r.RoleName
                        FROM Employees e
                        JOIN Roles r ON e.RoleID = r.RoleID
                        WHERE e.Username = @Username AND e.IsActive = 1";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", username);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read()) // Nếu tìm thấy user
                    {
                        byte[] storedHash = (byte[])reader["PasswordHash"];

                        // Xác thực mật khẩu
                        if (VerifyPassword(password, storedHash))
                        {
                            // Đăng nhập thành công, lưu thông tin user
                            CurrentUser.EmployeeID = (int)reader["EmployeeID"];
                            CurrentUser.FullName = reader["FullName"].ToString();
                            CurrentUser.RoleName = reader["RoleName"].ToString();

                            this.DialogResult = DialogResult.OK; // Báo hiệu đăng nhập thành công
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else // Không tìm thấy user hoặc user không hoạt động
                    {
                        MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hash mật khẩu (phải giống hệt hàm trong form quản lý nhân viên)
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        // Hàm xác thực mật khẩu
        private bool VerifyPassword(string enteredPassword, byte[] storedHash)
        {
            byte[] enteredHash = HashPassword(enteredPassword);
            // So sánh hai mảng byte
            if (enteredHash.Length != storedHash.Length) return false;
            for (int i = 0; i < enteredHash.Length; i++)
            {
                if (enteredHash[i] != storedHash[i]) return false;
            }
            return true;
        }
    }
}
