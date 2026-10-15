using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TimekeepingPayroll
{
    class Program
    {
        private static readonly CultureInfo VnCulture = new CultureInfo("vi-VN");

        static void Main(string[] args)
        {
            // Thiết lập font và encoding UTF-8 để hiển thị tiếng Việt trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Title = "Hệ thống Chấm công và Tính lương C# OOP (4 Lớp)";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("====================================================================================================");
            Console.WriteLine("                  CHƯƠNG TRÌNH QUẢN LÝ CHẤM CÔNG VÀ TÍNH LƯƠNG NHÂN VIÊN                            ");
            Console.WriteLine("====================================================================================================");
            Console.ResetColor();

            // ==============================================================================
            // BƯỚC 1: KHỞI TẠO 10 NHÂN VIÊN THEO DỮ LIỆU ĐỀ BÀI (KỲ 09/2026)
            // ==============================================================================
            var employees = new List<Employee>
            {
                new FullTimeEmployee("NV01", "Nguyễn Văn An", 13_000_000m, 65_000m, 0.10m),
                new PartTimeEmployee("NV02", "Trần Thị Bình", 50_000m),
                new FullTimeEmployee("NV03", "Lê Văn Chi", 15_600_000m, 75_000m, 0.05m),
                new PartTimeEmployee("NV04", "Phạm Quốc Dũng", 55_000m),
                new FullTimeEmployee("NV05", "Hoàng Minh Em", 10_400_000m, 50_000m, 0.00m),
                new PartTimeEmployee("NV06", "Võ Thị Phương", 48_000m),
                new FullTimeEmployee("NV07", "Lê Thu Giang", 18_200_000m, 90_000m, 0.075m),
                new PartTimeEmployee("NV08", "Đỗ Thị Hạnh", 60_000m),
                new FullTimeEmployee("NV09", "Ngô Minh Khang", 11_700_000m, 60_000m, 0.025m),
                new PartTimeEmployee("NV10", "Bùi Ngọc Linh", 45_000m)
            };

            // ==============================================================================
            // BƯỚC 2: NẠP DỮ LIỆU CHẤM CÔNG KỲ 09/2026
            // ==============================================================================
            var attendanceData = new (string Id, decimal Chuẩn, decimal Ca, decimal OT)[]
            {
                ("NV01", 26m, 24m,   8m),
                ("NV02", 26m, 10m,   5m),
                ("NV03", 26m, 25m,   2m),
                ("NV04", 26m, 12m,   4m),
                ("NV05", 26m, 22m,   0m),
                ("NV06", 26m, 14.5m, 2m),
                ("NV07", 26m, 26m,   3.5m),
                ("NV08", 26m, 8m,    3m),
                ("NV09", 26m, 23.5m, 6m),
                ("NV10", 26m, 16m,   3m)
            };

            int salaryMonth = 9;
            int salaryYear = 2026;

            foreach (var item in attendanceData)
            {
                var emp = employees.FirstOrDefault(e => e.Id.Equals(item.Id, StringComparison.OrdinalIgnoreCase));
                if (emp != null)
                {
                    // Nạp chồng AddAttendances truyền trực tiếp tham số
                    emp.AddAttendances(salaryMonth, salaryYear, item.Chuẩn, item.Ca, item.OT);
                }
            }

            // ==============================================================================
            // BƯỚC 3: TÍNH LƯƠNG ĐA HÌNH VÀ HIỂN THỊ BẢNG LƯƠNG (KHÔNG DÙNG IF/ELSE/SWITCH)
            // ==============================================================================
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"====================================================================================================");
            Console.WriteLine($"                        BẢNG LƯƠNG CHI TIẾT KỲ: {salaryMonth:D2}/{salaryYear}                                   ");
            Console.WriteLine($"====================================================================================================");
            Console.ResetColor();

            string header = string.Format("| {0,-6} | {1,-18} | {2,-11} | {3,18} | {4,14} | {5,18} |",
                "Mã NV", "Họ và tên", "Loại", "Lương theo công", "Thưởng", "Tổng thu nhập");
            string separator = "+" + new string('-', 8) + "+" + new string('-', 20) + "+" + new string('-', 13) +
                               "+" + new string('-', 20) + "+" + new string('-', 16) + "+" + new string('-', 20) + "+";

            Console.WriteLine(separator);
            Console.WriteLine(header);
            Console.WriteLine(separator);

            decimal totalWorkSalary = 0;
            decimal totalBonus = 0;
            decimal totalPayrollFund = 0;

            foreach (var emp in employees)
            {
                // Gọi phương thức Đa hình (Polymorphism):
                // Mỗi loại nhân viên tự chạy công thức của mình, không cần if/else hay switch
                var (luongTheoCong, thuong, tongThuNhap) = emp.CalculateSalary(salaryMonth, salaryYear);

                totalWorkSalary += luongTheoCong;
                totalBonus += thuong;
                totalPayrollFund += tongThuNhap;

                string row = string.Format("| {0,-6} | {1,-18} | {2,-11} | {3,16} đ | {4,12} đ | {5,16} đ |",
                    emp.Id,
                    emp.Name,
                    emp.GetEmployeeType(),
                    FormatMoney(luongTheoCong),
                    FormatMoney(thuong),
                    FormatMoney(tongThuNhap));

                Console.WriteLine(row);
            }

            Console.WriteLine(separator);

            // In dòng tổng cộng
            Console.ForegroundColor = ConsoleColor.Yellow;
            string totalRow = string.Format("| {0,-38} | {1,16} đ | {2,12} đ | {3,16} đ |",
                "TỔNG CỘNG QUỸ LƯƠNG",
                FormatMoney(totalWorkSalary),
                FormatMoney(totalBonus),
                FormatMoney(totalPayrollFund));
            Console.WriteLine(totalRow);
            Console.ResetColor();
            Console.WriteLine(separator);

            // In tóm tắt tổng kết
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[TỔNG KẾT QUỸ LƯƠNG KỲ {salaryMonth:D2}/{salaryYear}]");
            Console.WriteLine($"  - Tổng lương theo công : {FormatMoney(totalWorkSalary)} đồng");
            Console.WriteLine($"  - Tổng thưởng          : {FormatMoney(totalBonus)} đồng");
            Console.WriteLine($"  - TỔNG QUỸ LƯƠNG       : {FormatMoney(totalPayrollFund)} đồng");
            Console.ResetColor();
            Console.WriteLine();
        }

        private static string FormatMoney(decimal amount)
        {
            return amount.ToString("#,##0", VnCulture);
        }
    }
}