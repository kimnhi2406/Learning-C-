using System;

namespace TimekeepingPayroll
{
    /// <summary>
    /// Lớp 4: Nhân viên Part-time (PartTimeEmployee)
    /// Kế thừa (Inheritance) từ Employee, ghi đè (Override) phương thức tính lương.
    /// </summary>
    public class PartTimeEmployee : Employee
    {
        /// <summary>
        /// Với Part-time, BaseSalary đóng vai trò là lương cơ bản theo giờ (Hourly Wage).
        /// Đơn giá OT bằng lương cơ bản theo giờ, không có thưởng.
        /// </summary>
        public PartTimeEmployee(string id, string name, decimal hourlyWage)
            : base(id, name, hourlyWage)
        {
        }

        public override string GetEmployeeType()
        {
            return "Part-time";
        }

        /// <summary>
        /// Ghi đè (Override) công thức tính lương cho Part-time.
        /// Công chuẩn vẫn được lưu nhưng không tham gia tính toán.
        /// </summary>
        public override (decimal LuongTheoCong, decimal Thuong, decimal TongThuNhap) CalculateSalary(Attendances attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance), "Bản ghi chấm công không được null.");

            // Công thức Part-time:
            // Lương theo công = (Công ca + Công OT) × Lương cơ bản theo giờ
            decimal luongTheoCong = (attendance.CongCa + attendance.CongOT) * BaseSalary;

            // Part-time không có thưởng
            decimal thuong = 0m;

            // Tổng thu nhập làm tròn 1 lần đến đồng gần nhất, 0.5 làm tròn lên
            decimal tongThuNhap = Math.Round(luongTheoCong + thuong, 0, MidpointRounding.AwayFromZero);

            // Ràng buộc nghiệp vụ: Tổng thu nhập Part-time phải < 1.000.000 đồng
            if (tongThuNhap >= 1000000m)
            {
                throw new InvalidOperationException(
                    $"[Lỗi nghiệp vụ] Nhân viên Part-time {Id} - {Name}: Tổng thu nhập kỳ {attendance.Month:D2}/{attendance.Year} ({tongThuNhap:N0} đ) phải nhỏ hơn 1.000.000 đ.");
            }

            return (luongTheoCong, thuong, tongThuNhap);
        }
    }
}
