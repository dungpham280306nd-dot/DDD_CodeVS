using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp.DAL
{
    public class ProductDAL
    {
        public DataTable GetAvailableProducts(string searchTerm = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                // CẬP NHẬT QUERY
                string query = @"
            SELECT ProductID, ProductName, UnitPrice, Stock 
            FROM Products 
            WHERE IsDiscontinued = 0 AND Stock > 0";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " AND ProductName LIKE @SearchTerm";
                }
                // ... phần code còn lại của hàm giữ nguyên ...
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                }
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable GetProductDetailsForManagement(string searchTerm = "")
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                // Câu query này lấy đầy đủ thông tin hơn
                string query = @"
            SELECT 
                p.ProductID, p.ProductName, c.CategoryName, s.SupplierName, 
                p.UnitPrice, p.UnitCost, p.Stock, p.IsDiscontinued 
            FROM Products p
            LEFT JOIN Categories c ON p.CategoryID = c.CategoryID
            LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID";

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query += " WHERE p.ProductName LIKE @SearchTerm";
                }

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    da.SelectCommand.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");
                }
                da.Fill(dt);
            }
            return dt;
        }

        public bool InsertProduct(ProductDTO product)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    INSERT INTO Products (ProductName, CategoryID, SupplierID, UnitPrice, UnitCost, Stock, IsDiscontinued)
                    VALUES (@ProductName, @CategoryID, @SupplierID, @UnitPrice, @UnitCost, @Stock, @IsDiscontinued)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@CategoryID", (object)product.CategoryID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierID", (object)product.SupplierID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitCost", product.UnitCost);
                cmd.Parameters.AddWithValue("@Stock", product.Stock);
                cmd.Parameters.AddWithValue("@IsDiscontinued", product.IsDiscontinued);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // Trả về true nếu có dòng được thêm
            }
        }

        public bool UpdateProduct(ProductDTO product)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = @"
                    UPDATE Products SET 
                        ProductName = @ProductName, CategoryID = @CategoryID, SupplierID = @SupplierID, 
                        UnitPrice = @UnitPrice, UnitCost = @UnitCost, Stock = @Stock, IsDiscontinued = @IsDiscontinued
                    WHERE ProductID = @ProductID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@CategoryID", (object)product.CategoryID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierID", (object)product.SupplierID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
                cmd.Parameters.AddWithValue("@UnitCost", product.UnitCost);
                cmd.Parameters.AddWithValue("@Stock", product.Stock);
                cmd.Parameters.AddWithValue("@IsDiscontinued", product.IsDiscontinued);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // Trả về true nếu có dòng được cập nhật
            }
        }

        public bool SoftDeleteProduct(int productId)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Products SET IsDiscontinued = 1 WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProductID", productId);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0; // Trả về true nếu có dòng được cập nhật
            }
        }
    }
}
