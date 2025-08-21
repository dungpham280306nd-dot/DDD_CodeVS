using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreXManagerApp
{
    public partial class frmOrderHistory : Form
    {
        public frmOrderHistory()
        {
            InitializeComponent();
        }

        private void frmOrderHistory_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định cho bộ lọc ngày
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;

            LoadCustomerFilter();
            LoadOrders();
        }

        private void LoadCustomerFilter()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT CustomerID, CustomerName FROM Customers ORDER BY CustomerName", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // Thêm một dòng "Tất cả" vào đầu danh sách
                    DataRow dr = dt.NewRow();
                    dr["CustomerID"] = DBNull.Value; // Hoặc 0, tùy cách xử lý
                    dr["CustomerName"] = "-- Tất cả khách hàng --";
                    dt.Rows.InsertAt(dr, 0);

                    cboCustomerFilter.DataSource = dt;
                    cboCustomerFilter.DisplayMember = "CustomerName";
                    cboCustomerFilter.ValueMember = "CustomerID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOrders()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    // Câu query phức tạp hơn để lấy thông tin từ nhiều bảng
                    string query = @"
                        SELECT 
                            o.OrderID,
                            o.OrderDate,
                            c.CustomerName,
                            e.FullName AS EmployeeName,
                            o.TotalAmount,
                            o.Status
                        FROM Orders o
                        LEFT JOIN Customers c ON o.CustomerID = c.CustomerID
                        JOIN Employees e ON o.EmployeeID = e.EmployeeID
                        WHERE o.OrderDate BETWEEN @FromDate AND @ToDate";

                    // Thêm điều kiện lọc theo khách hàng nếu được chọn
                    if (cboCustomerFilter.SelectedValue != null && cboCustomerFilter.SelectedValue != DBNull.Value)
                    {
                        query += " AND o.CustomerID = @CustomerID";
                    }

                    query += " ORDER BY o.OrderDate DESC";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    // Thêm tham số cho bộ lọc
                    da.SelectCommand.Parameters.AddWithValue("@FromDate", dtpFromDate.Value.Date);
                    da.SelectCommand.Parameters.AddWithValue("@ToDate", dtpToDate.Value.Date.AddDays(1).AddTicks(-1)); // Lấy đến cuối ngày

                    if (cboCustomerFilter.SelectedValue != null && cboCustomerFilter.SelectedValue != DBNull.Value)
                    {
                        da.SelectCommand.Parameters.AddWithValue("@CustomerID", cboCustomerFilter.SelectedValue);
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOrders.DataSource = dt;

                    // Xóa dữ liệu cũ của chi tiết đơn hàng
                    dgvOrderDetails.DataSource = null;
                    lblOrderDetails.Text = "Chi tiết đơn hàng:";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count > 0)
            {
                int orderId = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["OrderID"].Value);
                LoadOrderDetails(orderId);
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT
                            p.ProductName,
                            od.Quantity,
                            od.UnitPrice,
                            od.LineTotal
                        FROM OrderDetails od
                        JOIN Products p ON od.ProductID = p.ProductID
                        WHERE od.OrderID = @OrderID";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.SelectCommand.Parameters.AddWithValue("@OrderID", orderId);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvOrderDetails.DataSource = dt;

                    // Cập nhật label
                    lblOrderDetails.Text = $"Chi tiết đơn hàng (Mã ĐH: {orderId})";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải chi tiết đơn hàng {orderId}: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            // Reset các control về trạng thái ban đầu
            dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            dtpToDate.Value = DateTime.Now;
            cboCustomerFilter.SelectedIndex = 0;

            // Tải lại toàn bộ đơn hàng
            LoadOrders();
        }

        private void cboCustomerFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
