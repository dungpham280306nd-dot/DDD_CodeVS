using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DTO;
using StoreXManagerApp;
using System.Data.SqlClient;

namespace StoreXManager.DAL
{
    public class CustomerDAL
    {
        /// <summary>
        /// Lấy danh sách khách hàng, có hỗ trợ tìm kiếm theo tên hoặc SĐT.
        /// </summary>
        public DataTable GetCustomers(string searchTerm = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "SELECT CustomerID, CustomerName, Address, Phone, Email FROM Customers";
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE CustomerName LIKE @SearchTerm OR Phone LIKE @SearchTerm";
                }
                query += " ORDER BY CustomerName";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                }
                da.Fill(dt);
            }
            return dt;
        }

        /// <summary>
        /// Thêm một khách hàng mới vào CSDL.
        /// </summary>
        public bool InsertCustomer(CustomerDTO customer)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Customers (CustomerName, Address, Phone, Email) VALUES (@Name, @Address, @Phone, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", customer.CustomerName);
                cmd.Parameters.AddWithValue("@Address", (object)customer.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Email", (object)customer.Email ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Cập nhật thông tin một khách hàng trong CSDL.
        /// </summary>
        public bool UpdateCustomer(CustomerDTO customer)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    UPDATE Customers SET 
                        CustomerName = @Name, Address = @Address, Phone = @Phone, Email = @Email
                    WHERE CustomerID = @CustomerID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@Name", customer.CustomerName);
                cmd.Parameters.AddWithValue("@Address", (object)customer.Address ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Email", (object)customer.Email ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Xóa một khách hàng khỏi CSDL.
        /// </summary>
        public bool DeleteCustomer(int customerId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CustomerID", customerId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
