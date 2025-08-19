using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DAL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp.BLL
{
    public class OrderBLL
    {
        private readonly OrderDAL _orderDAL = new OrderDAL();

        public int CreateOrder(OrderDTO order)
        {
            // Logic nghiệp vụ: Kiểm tra dữ liệu đơn hàng
            if (order == null)
                throw new ArgumentNullException(nameof(order), "Thông tin đơn hàng không thể rỗng.");

            if (order.CustomerID <= 0)
                throw new Exception("Vui lòng chọn khách hàng hợp lệ.");

            if (order.EmployeeID <= 0)
                throw new Exception("Vui lòng chọn nhân viên hợp lệ.");

            if (order.OrderItems == null || order.OrderItems.Count == 0)
                throw new Exception("Giỏ hàng không được để trống.");

            // Nếu dữ liệu hợp lệ, gọi DAL để tạo đơn hàng
            return _orderDAL.CreateOrder(order);
        }
    }
}
