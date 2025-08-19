using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoreXManagerApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bắt đầu một vòng lặp để có thể đăng xuất và đăng nhập lại
            while (true)
            {
                // Trong mỗi vòng lặp, tạo một form đăng nhập mới
                frmLogin loginForm = new frmLogin();

                // Hiển thị form đăng nhập. Nếu người dùng đăng nhập thành công,
                // ShowDialog() sẽ trả về DialogResult.OK.
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu đăng nhập thành công, chạy Form chính.
                    // Application.Run() sẽ giữ cho ứng dụng chạy cho đến khi Form1 được đóng.
                    Application.Run(new Form1());
                }
                else
                {
                    // Nếu người dùng nhấn "Thoát" hoặc đóng cửa sổ đăng nhập,
                    // ShowDialog() sẽ không trả về OK.
                    // Chúng ta sẽ thoát khỏi vòng lặp và kết thúc ứng dụng.
                    break;
                }
            }
        }
    }
}
