using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DAL;
using StoreXManagerApp.DTO;

namespace StoreXManagerApp.BLL
{
    public class ProductBLL
    {
        private readonly ProductDAL _productDAL = new ProductDAL();

        public DataTable GetAvailableProducts(string searchTerm = "")
        {
            return _productDAL.GetAvailableProducts(searchTerm);
        }
        public DataTable GetProductDetailsForManagement(string searchTerm = "")
        {
            return _productDAL.GetProductDetailsForManagement(searchTerm);
        }

        public bool InsertProduct(ProductDTO product)
        {
            // Có thể thêm logic kiểm tra dữ liệu ở đây trước khi gọi DAL
            // Ví dụ: if (product.UnitPrice < product.UnitCost) return false;
            return _productDAL.InsertProduct(product);
        }

        public bool UpdateProduct(ProductDTO product)
        {
            return _productDAL.UpdateProduct(product);
        }

        public bool SoftDeleteProduct(int productId)
        {
            return _productDAL.SoftDeleteProduct(productId);
        }
    }
}
