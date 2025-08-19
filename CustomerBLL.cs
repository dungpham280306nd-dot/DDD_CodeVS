using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreXManager.DAL;
using StoreXManagerApp.DTO;

namespace StoreXManager.BLL
{
    public class CustomerBLL
    {
        private readonly CustomerDAL _customerDAL = new CustomerDAL();

        public DataTable GetCustomers(string searchTerm = "")
        {
            return _customerDAL.GetCustomers(searchTerm);
        }

        public bool InsertCustomer(CustomerDTO customer)
        {
            // Logic nghiệp vụ: Tên và SĐT là bắt buộc
            if (string.IsNullOrWhiteSpace(customer.CustomerName) || string.IsNullOrWhiteSpace(customer.Phone))
            {
                throw new Exception("Tên khách hàng và Số điện thoại không được để trống.");
            }
            return _customerDAL.InsertCustomer(customer);
        }

        public bool UpdateCustomer(CustomerDTO customer)
        {
            // Logic nghiệp vụ: Tên và SĐT là bắt buộc
            if (string.IsNullOrWhiteSpace(customer.CustomerName) || string.IsNullOrWhiteSpace(customer.Phone))
            {
                throw new Exception("Tên khách hàng và Số điện thoại không được để trống.");
            }
            return _customerDAL.UpdateCustomer(customer);
        }

        public bool DeleteCustomer(int customerId)
        {
            return _customerDAL.DeleteCustomer(customerId);
        }
    }
}
