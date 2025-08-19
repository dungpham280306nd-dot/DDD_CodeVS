using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreXManagerApp.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Dùng để truyền mật khẩu mới (chuỗi thô)
        public int RoleID { get; set; }
        public bool IsActive { get; set; }
    }
}
