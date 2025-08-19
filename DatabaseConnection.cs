using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreXManagerApp
{
    public static class DatabaseConnection
    {
        // THAY ĐỔI CHUỖI KẾT NỐI NÀY CHO PHÙ HỢP VỚI MÁY CỦA BẠN
        // Data Source: Tên server SQL của bạn (tìm trong SSMS)
        // Initial Catalog: Tên database
        // Integrated Security=True: Dùng xác thực Windows
        private const string connectionString = @"Data Source=.\SQLEXPRESS
;Initial Catalog=StoreX_Advanced;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
