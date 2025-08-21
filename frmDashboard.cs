// Dán toàn bộ code này vào file frmDashboard.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
// Quan trọng: using này để sử dụng các lớp Chart, Series...
using System.Windows.Forms.DataVisualization.Charting;

namespace StoreXManagerApp
{
    public partial class frmDashboard : Form
    {
        #region Constructor & Form Events

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị báo cáo cho 30 ngày gần nhất
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;

            LoadAllDashboardData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadAllDashboardData();
        }

        #endregion

        #region Data Loading & Charting

        /// <summary>
        /// Hàm chính để gọi và làm mới tất cả dữ liệu trên Dashboard.
        /// </summary>
        private void LoadAllDashboardData()
        {
            LoadKpiData();
            LoadTopProductsChart();
            LoadRevenueByEmployeeChart();
        }

        /// <summary>
        /// Tải các chỉ số KPI chính: Doanh thu, Lợi nhuận, Số đơn hàng.
        /// </summary>
        private void LoadKpiData()
        {
            try
            {
                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT 
                            ISNULL(SUM(od.LineTotal), 0) AS TotalRevenue,
                            ISNULL(SUM(od.LineTotal - (p.UnitCost * od.Quantity)), 0) AS TotalProfit,
                            COUNT(DISTINCT o.OrderID) AS TotalOrders
                        FROM Orders o
                        JOIN OrderDetails od ON o.OrderID = od.OrderID
                        JOIN Products p ON od.ProductID = p.ProductID
                        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    AddDateParametersToCommand(cmd); // Tái sử dụng code thêm tham số

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    CultureInfo viVn = new CultureInfo("vi-VN");

                    if (reader.Read())
                    {
                        lblTotalRevenue.Text = $"Revenue: {Convert.ToDecimal(reader["TotalRevenue"]).ToString("C0", viVn)}";
                        lblTotalProfit.Text = $"Profit: {Convert.ToDecimal(reader["TotalProfit"]).ToString("C0", viVn)}";
                        lblTotalOrders.Text = $"Order Number: {reader["TotalOrders"]}";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading KPI data: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải và vẽ biểu đồ cột cho Top 5 sản phẩm bán chạy nhất.
        /// </summary>
        private void LoadTopProductsChart()
        {
            try
            {
                // Xóa dữ liệu cũ trên biểu đồ
                chartTopProducts.Series.Clear();

                // Tạo một Series mới cho biểu đồ
                Series series = new Series("Sales volume")
                {
                    ChartType = SeriesChartType.Bar
                };

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT TOP 5
                            p.ProductName,
                            SUM(od.Quantity) AS TotalQuantitySold
                        FROM OrderDetails od
                        JOIN Products p ON od.ProductID = p.ProductID
                        JOIN Orders o ON o.OrderID = od.OrderID
                        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                        GROUP BY p.ProductName
                        ORDER BY TotalQuantitySold DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    AddDateParametersToCommand(cmd);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Đọc từng dòng dữ liệu và thêm trực tiếp vào Series
                        while (reader.Read())
                        {
                            series.Points.AddXY(reader["ProductName"], reader["TotalQuantitySold"]);
                        }
                    }
                }

                // Thêm Series đã có dữ liệu vào biểu đồ
                chartTopProducts.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product chart: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải và vẽ biểu đồ tròn cho doanh thu theo từng nhân viên.
        /// </summary>
        private void LoadRevenueByEmployeeChart()
        {
            try
            {
                chartRevenueByEmployee.Series.Clear();

                Series series = new Series("Revenue")
                {
                    ChartType = SeriesChartType.Pie,
                    IsValueShownAsLabel = true // Hiển thị giá trị trên lát bánh
                };

                using (SqlConnection conn = DatabaseConnection.GetConnection())
                {
                    string query = @"
                        SELECT
                            e.FullName,
                            SUM(od.LineTotal) AS TotalRevenue
                        FROM Orders o
                        JOIN Employees e ON o.EmployeeID = e.EmployeeID
                        JOIN OrderDetails od ON o.OrderID = od.OrderID
                        WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                        GROUP BY e.FullName
                        HAVING SUM(od.LineTotal) > 0
                        ORDER BY TotalRevenue DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    AddDateParametersToCommand(cmd);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Thêm điểm dữ liệu, đồng thời định dạng Label cho đẹp
                            DataPoint dataPoint = new DataPoint();
                            dataPoint.SetValueXY(reader["FullName"], reader["TotalRevenue"]);
                            dataPoint.Label = $"{Convert.ToDecimal(reader["TotalRevenue"]):N0}đ";
                            dataPoint.LegendText = reader["FullName"].ToString();
                            series.Points.Add(dataPoint);
                        }
                    }
                }

                chartRevenueByEmployee.Series.Add(series);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee chart: " + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Hàm phụ trợ để thêm các tham số ngày tháng vào một SqlCommand.
        /// </summary>
        /// <param name="cmd">Đối tượng SqlCommand cần thêm tham số.</param>
        private void AddDateParametersToCommand(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
            // Kỹ thuật này đảm bảo lấy hết dữ liệu đến cuối ngày được chọn (23:59:59.999)
            cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date.AddDays(1).AddTicks(-1));
        }

        #endregion

        private void panelKpi_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chartRevenueByEmployee_Click(object sender, EventArgs e)
        {

        }

        private void lblTotalRevenue_Click(object sender, EventArgs e)
        {

        }

        private void chartTopProducts_Click(object sender, EventArgs e)
        {

        }
    }
}
