using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DAL;

namespace StoreXManagerApp.BLL
{
    public class CategoryBLL
    {
        private CategoryDAL categoryDAL = new CategoryDAL();

        public DataTable GetAllCategories()
        {
            // Trong tương lai, bạn có thể thêm các quy tắc nghiệp vụ ở đây
            // Ví dụ: kiểm tra quyền, lọc danh mục...
            return categoryDAL.GetAllCategories();
        }
    }
}
