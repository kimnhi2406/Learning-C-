using System;

namespace TimekeepingPayroll
{
    /// <summary>
    /// Lớp 1: Bảng công (Attendances)
    /// Áp dụng tính Đóng gói (Encapsulation) và Nạp chồng Constructor (Overload).
    /// </summary>
    public class Attendances
    {
        public int Month { get; private set; }
        public int Year { get; private set; }
        public decimal CongChuan { get; private set; }
        public decimal CongCa { get; private set; }
        public decimal CongOT { get; private set; }

        
        /// Khởi tạo đầy đủ các thông số công.
        public Attendances(int month, int year, decimal congChuan, decimal congCa, decimal congOT)
        {
            Validate(month, year, congChuan, congCa, congOT);

            Month = month;
            Year = year;
            CongChuan = congChuan;
            CongCa = congCa;
            CongOT = congOT;
        }

        /// <summary>
        /// Nạp chồng Constructor (Overload): Mặc định công chuẩn là 26 ngày nếu không truyền vào.
        /// </summary>
        public Attendances(int month, int year, decimal congCa, decimal congOT)
            : this(month, year, 26m, congCa, congOT)
        {
        }

        private static void Validate(int month, int year, decimal congChuan, decimal congCa, decimal congOT)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Tháng phải nằm trong khoảng từ 1 đến 12.");

            if (year <= 0)
                throw new ArgumentOutOfRangeException(nameof(year), "Năm phải lớn hơn 0.");

            if (congChuan <= 0)
                throw new ArgumentOutOfRangeException(nameof(congChuan), "Công chuẩn phải lớn hơn 0.");

            if (congCa < 0)
                throw new ArgumentOutOfRangeException(nameof(congCa), "Công ca không được âm (>= 0).");

            if (congOT < 0)
                throw new ArgumentOutOfRangeException(nameof(congOT), "Công OT không được âm (>= 0).");
        }

        public override string ToString()
        {
            return $"Kỳ: {Month:D2}/{Year} | Chuẩn: {CongChuan} | Ca: {CongCa} | OT: {CongOT}";
        }
    }
}
