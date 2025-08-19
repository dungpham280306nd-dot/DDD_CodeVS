using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StoreXManagerApp.DAL
{
    public class CategoryDAL
    {
        public DataTable GetAllCategories()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                // Toàn bộ logic truy vấn CSDL nằm ở đây
                string query = "SELECT CategoryID, CategoryName FROM Categories ORDER BY CategoryName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
