using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp;
using System.Data.SqlClient;

namespace StoreXManager.DAL
{
    public class EmployeeDAL
    {
        public DataTable GetEmployees()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT e.EmployeeID, e.FullName, e.Username, r.RoleName, e.IsActive
                    FROM Employees e
                    JOIN Roles r ON e.RoleID = r.RoleID
                    WHERE e.IsActive = 1 
                    ORDER BY e.FullName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }

        // DAL chỉ nhận mật khẩu đã được hash dưới dạng mảng byte
        public bool InsertEmployee(string fullName, string username, byte[] passwordHash, int roleId, bool isActive)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO Employees (FullName, Username, PasswordHash, RoleID, IsActive)
                    VALUES (@FullName, @Username, @PasswordHash, @RoleID, @IsActive)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 64).Value = passwordHash;
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Có 2 phiên bản Update: một có đổi mật khẩu, một không
        public bool UpdateEmployee(int employeeId, string fullName, string username, int roleId, bool isActive)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    UPDATE Employees SET FullName = @FullName, Username = @Username, RoleID = @RoleID, IsActive = @IsActive
                    WHERE EmployeeID = @EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateEmployeeWithPassword(int employeeId, string fullName, string username, byte[] passwordHash, int roleId, bool isActive)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    UPDATE Employees SET 
                        FullName = @FullName, Username = @Username, PasswordHash = @PasswordHash, 
                        RoleID = @RoleID, IsActive = @IsActive
                    WHERE EmployeeID = @EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.Add("@PasswordHash", SqlDbType.VarBinary, 64).Value = passwordHash;
                cmd.Parameters.AddWithValue("@RoleID", roleId);
                cmd.Parameters.AddWithValue("@IsActive", isActive);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public DataTable GetSalesEmployees()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
            SELECT e.EmployeeID, e.FullName 
            FROM Employees e 
            JOIN Roles r ON e.RoleID = r.RoleID 
            WHERE e.IsActive = 1 AND r.RoleName = 'Sales'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
        public bool DeleteEmployee(int employeeId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                // Câu lệnh UPDATE để vô hiệu hóa tài khoản thay vì xóa hẳn
                string query = "UPDATE Employees SET IsActive = 0 WHERE EmployeeID = @EmployeeID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // Trả về true nếu cập nhật thành công 1 dòng
            }
        }
    }
}
