using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using StoreXManager.DAL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp.BLL
{
    public class EmployeeBLL
    {
        private readonly EmployeeDAL _employeeDAL = new EmployeeDAL();

        public DataTable GetEmployees()
        {
            return _employeeDAL.GetEmployees();
        }

        public bool InsertEmployee(EmployeeDTO employee)
        {
            // Logic nghiệp vụ: Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(employee.FullName) || string.IsNullOrWhiteSpace(employee.Username) || string.IsNullOrWhiteSpace(employee.Password))
            {
                throw new Exception("Họ tên, Tên đăng nhập và Mật khẩu là bắt buộc.");
            }

            // Logic nghiệp vụ: Hash mật khẩu
            byte[] passwordHash = HashPassword(employee.Password);

            // Gọi DAL để lưu vào CSDL
            return _employeeDAL.InsertEmployee(employee.FullName, employee.Username, passwordHash, employee.RoleID, employee.IsActive);
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            if (string.IsNullOrWhiteSpace(employee.FullName) || string.IsNullOrWhiteSpace(employee.Username))
            {
                throw new Exception("Họ tên và Tên đăng nhập là bắt buộc.");
            }

            // Logic nghiệp vụ: Kiểm tra xem người dùng có muốn đổi mật khẩu không
            if (string.IsNullOrWhiteSpace(employee.Password))
            {
                // Gọi phiên bản Update không có mật khẩu
                return _employeeDAL.UpdateEmployee(employee.EmployeeID, employee.FullName, employee.Username, employee.RoleID, employee.IsActive);
            }
            else
            {
                // Hash mật khẩu mới và gọi phiên bản Update có mật khẩu
                byte[] passwordHash = HashPassword(employee.Password);
                return _employeeDAL.UpdateEmployeeWithPassword(employee.EmployeeID, employee.FullName, employee.Username, passwordHash, employee.RoleID, employee.IsActive);
            }
        }

        /// <summary>
        /// Hàm hash mật khẩu bằng SHA256. Đây là logic nghiệp vụ, nên nó nằm ở BLL.
        /// </summary>
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
        public DataTable GetSalesEmployees()
        {
            return _employeeDAL.GetSalesEmployees();
        }
        public bool DeleteEmployee(int employeeId)
        {
            // Có thể thêm logic nghiệp vụ ở đây
            // Ví dụ: không cho phép vô hiệu hóa tài khoản admin cuối cùng
            // if (IsLastAdmin(employeeId)) { throw new Exception("Không thể vô hiệu hóa quản trị viên cuối cùng."); }

            return _employeeDAL.DeleteEmployee(employeeId);
        }
    }
}