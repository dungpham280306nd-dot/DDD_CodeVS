using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp.DTO
{
    public class OrderDTO
    {
        // Thông tin chung của đơn hàng
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }

        // Danh sách các sản phẩm trong đơn hàng
        public List<OrderDetailDTO> OrderItems { get; set; }

        public OrderDTO()
        {
            OrderItems = new List<OrderDetailDTO>();
        }
    }
}
