namespace TimekeepingPayroll
{
    /// <summary>
    /// Giao diện định nghĩa hợp đồng tính lương (Interface).
    /// Đảm bảo tính trừu tượng và hỗ trợ đa hình mà không cần thêm lớp phụ.
    /// </summary>
    public interface IPayrollCalculable
    {
        /// <summary>
        /// Nạp chồng (Overload): Tính lương theo tháng/năm từ danh sách chấm công đã lưu.
        /// </summary>
        (decimal LuongTheoCong, decimal Thuong, decimal TongThuNhap) CalculateSalary(int month, int year);

        /// <summary>
        /// Nạp chồng (Overload): Tính lương trực tiếp với một bản ghi chấm công.
        /// </summary>
        (decimal LuongTheoCong, decimal Thuong, decimal TongThuNhap) CalculateSalary(Attendances attendance);
    }
}
