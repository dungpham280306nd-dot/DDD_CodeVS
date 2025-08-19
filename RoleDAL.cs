using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StoreXManagerApp.DAL
{
    public class RoleDAL
    {
        /// <summary>
        /// Lấy tất cả các vai trò từ cơ sở dữ liệu.
        /// </summary>
        /// <returns>Một DataTable chứa danh sách vai trò.</returns>
        public DataTable GetAllRoles()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT RoleID, RoleName FROM Roles ORDER BY RoleName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
