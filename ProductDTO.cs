using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreXManagerApp.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; } // Dùng int? để cho phép giá trị NULL
        public int? SupplierID { get; set; } // Dùng int? để cho phép giá trị NULL
        public decimal UnitPrice { get; set; }
        public decimal UnitCost { get; set; }
        public int Stock { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}
