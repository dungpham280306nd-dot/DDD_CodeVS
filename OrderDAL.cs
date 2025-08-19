using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DTO;
using System.Data.SqlClient;


namespace StoreXManagerApp.DAL
{
    public class OrderDAL
    {
        /// <summary>
        /// Tạo một đơn hàng mới bằng cách sử dụng Transaction.
        /// </summary>
        /// <returns>Trả về OrderID nếu thành công, ngược lại trả về 0.</returns>
        public int CreateOrder(OrderDTO order)
        {
            using (SqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Bắt đầu một Transaction
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Bước 1: Thêm vào bảng Orders và lấy OrderID mới
                    string insertOrderQuery = "INSERT INTO Orders (CustomerID, EmployeeID, Status, OrderDate) OUTPUT INSERTED.OrderID VALUES (@CustomerID, @EmployeeID, 'Completed', GETDATE());";
                    SqlCommand cmdOrder = new SqlCommand(insertOrderQuery, conn, transaction);
                    cmdOrder.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmdOrder.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);

                    int newOrderID = (int)cmdOrder.ExecuteScalar();

                    // Bước 2: Duyệt qua từng sản phẩm và thêm vào OrderDetails
                    foreach (var item in order.OrderItems)
                    {
                        string insertDetailQuery = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice) VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice);";
                        SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, conn, transaction);
                        cmdDetail.Parameters.AddWithValue("@OrderID", newOrderID);
                        cmdDetail.Parameters.AddWithValue("@ProductID", item.ProductID);
                        cmdDetail.Parameters.AddWithValue("@Quantity", item.Quantity);
                        cmdDetail.Parameters.AddWithValue("@UnitPrice", item.UnitPrice);
                        cmdDetail.ExecuteNonQuery();
                    }

                    // Nếu mọi thứ thành công, xác nhận Transaction
                    transaction.Commit();
                    return newOrderID;
                }
                catch (Exception)
                {
                    // Nếu có bất kỳ lỗi nào, hủy bỏ toàn bộ Transaction
                    transaction.Rollback();
                    throw; // Ném lại lỗi để lớp BLL hoặc GUI có thể bắt và xử lý
                }
            }
        }
    }
}
