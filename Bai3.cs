  using System;
  using System.Collections.Generic;
  using System.Text;

  namespace LearnWithFastdoer
  {
    public class Bai3
    {
      public static void Run()
      {
        Console.WriteLine("Bài 1.9.4 — Phan loai so nguyen bang toan tu ba ngoi, ket hop typeof/sizeof");
        Console.WriteLine("Nhap so nguyen a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        string test = (a >0) ? "la so duong" : ((a<0) ? "la so am" : "la so 0");
        Console.WriteLine($"So vua nhap { test}");
        Console.WriteLine(typeof(int));
        Console.WriteLine(sizeof(int));


      Console.WriteLine("======================================================");

      Console.WriteLine("Bài 1.10.4 — Máy tính đơn giản bằng switch");
      Console.WriteLine("Nhap vao so thu 1: ");
      double soThuNhAT = Convert.ToDouble(Console.ReadLine());
      Console.WriteLine("Nhap phep toan: ");
      char phepToan = Convert.ToChar(Console.ReadLine());
      Console.WriteLine("Nhap vao so thu 2: ");
      double soThuHai = Convert.ToDouble(Console.ReadLine());
      double result;
      string thongBao;
      switch(phepToan)
      {
        case '+':
          result = soThuNhAT + soThuHai;
          Console.WriteLine($"Kết quả của phép tính: {result}");
          break;
        case '-':
          result = soThuNhAT - soThuHai;
          Console.WriteLine($"Kết quả của phép tính: {result}");
          break;
        case '*':
          result = soThuNhAT * soThuHai;
          Console.WriteLine($"Kết quả của phép tính: {result}");
          break;
        case '/':
          thongBao = (soThuHai != 0) ? $"kết quả là : {soThuNhAT / soThuHai} " : "Khong duoc chia cho 0";
          Console.WriteLine(thongBao);
          break;
        default:
          Console.WriteLine("Ký tự phép toán không hợp lệ");
          break;
      }  


      }
    }
  }
