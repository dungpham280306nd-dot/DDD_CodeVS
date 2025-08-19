using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DAL;

namespace StoreXManagerApp.BLL
{
    public class SupplierBLL
    {
        private SupplierDAL supplierDAL = new SupplierDAL();

        /// <summary>
        /// Lấy danh sách tất cả các nhà cung cấp.
        /// </summary>
        /// <returns>Một DataTable chứa danh sách nhà cung cấp.</returns>
        public DataTable GetAllSuppliers()
        {
            // Trong tương lai, các quy tắc nghiệp vụ liên quan đến nhà cung cấp sẽ được đặt ở đây.
            // Ví dụ: chỉ lấy các nhà cung cấp còn hợp tác.
            return supplierDAL.GetAllSuppliers();
        }
    }
}
