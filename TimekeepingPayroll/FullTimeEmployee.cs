using System;

namespace TimekeepingPayroll
{
    /// <summary>
    /// Lớp 3: Nhân viên Full-time (FullTimeEmployee)
    /// Kế thừa (Inheritance) từ Employee, ghi đè (Override) phương thức tính lương.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        public decimal OvertimeRate { get; private set; }
        public decimal BonusRate { get; private set; }

        public FullTimeEmployee(string id, string name, decimal baseSalary, decimal overtimeRate, decimal bonusRate)
            : base(id, name, baseSalary)
        {
            if (overtimeRate < 0)
                throw new ArgumentOutOfRangeException(nameof(overtimeRate), "Đơn giá OT không được âm.");

            if (bonusRate < 0)
                throw new ArgumentOutOfRangeException(nameof(bonusRate), "Tỷ lệ thưởng không được âm.");

            OvertimeRate = overtimeRate;
            BonusRate = bonusRate;
        }

        /// <summary>
        /// Nạp chồng Constructor (Overload): Trường hợp không có thưởng ban đầu (mặc định 0%).
        /// </summary>
        public FullTimeEmployee(string id, string name, decimal baseSalary, decimal overtimeRate)
            : this(id, name, baseSalary, overtimeRate, 0m)
        {
        }

        public override string GetEmployeeType()
        {
            return "Full-time";
        }

        /// <summary>
        /// Ghi đè (Override) công thức tính lương cho Full-time.
        /// </summary>
        public override (decimal LuongTheoCong, decimal Thuong, decimal TongThuNhap) CalculateSalary(Attendances attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance), "Bản ghi chấm công không được null.");

            if (attendance.CongChuan <= 0)
                throw new InvalidOperationException($"Công chuẩn phải lớn hơn 0 khi tính lương cho nhân viên {Id}.");

            // Công thức Full-time:
            // Lương theo công = (Lương cơ bản / Công chuẩn) × Công ca + Công OT × Đơn giá OT
            decimal luongTheoCong = (BaseSalary / attendance.CongChuan) * attendance.CongCa + attendance.CongOT * OvertimeRate;

            // Thưởng = Lương cơ bản × Tỷ lệ thưởng
            decimal thuong = BaseSalary * BonusRate;

            // Tổng thu nhập làm tròn 1 lần đến đồng gần nhất, 0.5 làm tròn lên
            decimal tongThuNhap = Math.Round(luongTheoCong + thuong, 0, MidpointRounding.AwayFromZero);

            // Ràng buộc nghiệp vụ: Tổng thu nhập Full-time phải > 1.000.000 đồng
            if (tongThuNhap <= 1000000m)
            {
                throw new InvalidOperationException(
                    $"[Lỗi nghiệp vụ] Nhân viên Full-time {Id} - {Name}: Tổng thu nhập kỳ {attendance.Month:D2}/{attendance.Year} ({tongThuNhap:N0} đ) phải lớn hơn 1.000.000 đ.");
            }

            return (luongTheoCong, thuong, tongThuNhap);
        }
    }
}
