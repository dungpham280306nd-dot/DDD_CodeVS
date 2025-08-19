using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StoreXManagerApp
{
    public class SupplierDAL
    {
        public DataTable GetAllSuppliers()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                // Logic truy vấn CSDL được đóng gói hoàn toàn trong lớp này.
                string query = "SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            return dt;
        }
    }
}
