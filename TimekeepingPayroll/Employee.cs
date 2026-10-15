using System;
using System.Collections.Generic;
using System.Linq;

namespace TimekeepingPayroll
{
    /// Đại diện cho nhân viên nói chung, triển khai giao diện IPayrollCalculable.
    /// Áp dụng tính Đóng gói (Encapsulation), Kế thừa (Inheritance), Nạp chồng (Overload) và Đa hình (Polymorphism).

    public abstract class Employee : IPayrollCalculable
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal BaseSalary { get; private set; }

        public List<Attendances> AttendanceList { get; private set; }

        protected Employee(string id, string name, decimal baseSalary)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Mã nhân viên không được để trống.", nameof(id));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Tên nhân viên không được để trống.", nameof(name));

            if (baseSalary < 0)
                throw new ArgumentOutOfRangeException(nameof(baseSalary), "Lương cơ bản không được âm.");

            Id = id.Trim();
            Name = name.Trim();
            BaseSalary = baseSalary;
            AttendanceList = new List<Attendances>();
        }


        /// Thêm bản ghi chấm công. Kiểm tra null và kiểm tra trùng tháng/năm.

        public void AddAttendances(Attendances attendance)
        {
            if (attendance == null)
                throw new ArgumentNullException(nameof(attendance), "Bản ghi chấm công không được null.");

            bool isDuplicate = AttendanceList.Any(a => a.Month == attendance.Month && a.Year == attendance.Year);
            if (isDuplicate)
            {
                throw new InvalidOperationException(
                    $"Nhân viên {Id} - {Name} đã có dữ liệu chấm công cho kỳ {attendance.Month:D2}/{attendance.Year}.");
            }

            AttendanceList.Add(attendance);
        }

        /// <summary>
        /// Nạp chồng (Overload Method): Cho phép thêm bản ghi chấm công trực tiếp bằng tham số số.
        /// </summary>
        public void AddAttendances(int month, int year, decimal congChuan, decimal congCa, decimal congOT)
        {
            AddAttendances(new Attendances(month, year, congChuan, congCa, congOT));
        }

        /// <summary>
        /// Tìm bản ghi chấm công của nhân viên theo tháng và năm.
        /// </summary>
        public Attendances GetAttendance(int month, int year)
        {
            var attendance = AttendanceList.FirstOrDefault(a => a.Month == month && a.Year == year);
            if (attendance == null)
            {
                throw new KeyNotFoundException(
                    $"Không tìm thấy dữ liệu chấm công kỳ {month:D2}/{year} của nhân viên {Id} - {Name}.");
            }
            return attendance;
        }

        /// <summary>
        /// Phương thức trừu tượng trả về loại nhân viên (Full-time, Part-time).
        /// </summary>
        public abstract string GetEmployeeType();

        /// <summary>
        /// Phương thức trừu tượng tính lương (Abstract Method).
        /// Mỗi loại nhân viên sẽ tự triển khai (Override) công thức của mình.
        /// </summary>
        public abstract (decimal LuongTheoCong, decimal Thuong, decimal TongThuNhap) CalculateSalary(Attendances attendance);

        /// <summary>
        /// Nạp chồng (Overload Method): Tính lương theo tháng/năm từ danh sách chấm công đã lưu.
        /// </summary>
        public (decimal LuongTheoCong, decimal Thuong, decimal TongThuNhap) CalculateSalary(int month, int year)
        {
            var attendance = GetAttendance(month, year);
            return CalculateSalary(attendance);
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} | Loại: {GetEmployeeType()} | Lương cơ bản: {BaseSalary:N0} đ";
        }
    }
}
