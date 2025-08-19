using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManagerApp.DAL;

namespace StoreXManagerApp.BLL
{
    public class RoleBLL
    {
        private readonly RoleDAL _roleDAL = new RoleDAL();

        /// <summary>
        /// Lấy danh sách tất cả các vai trò.
        /// </summary>
        /// <returns>Một DataTable chứa danh sách vai trò.</returns>
        public DataTable GetAllRoles()
        {
            return _roleDAL.GetAllRoles();
        }
    }
}
