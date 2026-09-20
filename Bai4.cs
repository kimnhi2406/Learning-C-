using System;

namespace LearnWithFastdoer
{
  public class Bai214
  {
    public static void Run()
    {
      Console.WriteLine("Bài 2.1.4:Tam giác số có giới hạn tổng mỗi dòng");
      int tongCuoi = 0;

      for (int i = 1; i <= 5; i++)
      {
        int tong = 0; 
        for (int j = 1; j <= i; j++)
        {
          if (tong + j >= 7)
            break;
          Console.Write(j);
          tong = tong + j;
        }
        Console.Write($"Tong la: {tong}");
        Console.WriteLine();
        tongCuoi = tongCuoi + tong;
      }
      Console.WriteLine($"Tong cuoi cung la: {tongCuoi}");
    }
  }

  public class TaiKhoan
  {
    private double soDu = 0;

    public void NapTien(double soTien)
    {
      if (soTien > 0)
      {
        soDu = soDu + soTien;
        Console.WriteLine($"Nạp thành công: {soTien}");
      }
      else
      {
        Console.WriteLine("Số tiền nạp phải lớn hơn 0");
      }
    }

    public void RutTien(double soTien)
    {
      if (soTien <= 0)
      {
        Console.WriteLine("số tiền không hợp lệ");
      }
      else if (soTien > soDu)
      {
        Console.WriteLine("số dư không đủ");
      }
      else
      {
        soDu = soDu - soTien;
        Console.WriteLine($"Rút thành công: {soTien}");
      }
    }

    public void XemSoDu()
    {
      Console.WriteLine($"Số dư hiện tại: {soDu}");
    }
  }

  public class Bai222
  {
    public static void Run()
    {
      Console.WriteLine("Bài 2.2.2");

      TaiKhoan tk = new TaiKhoan();

      tk.NapTien(500000);    
      tk.RutTien(200000);   
      tk.RutTien(1000000);  
      tk.NapTien(-100);     
      tk.XemSoDu();        
    }
  }

  public class Bai233
  {
    public static int LuyThua(int x, int y)
    {
      int ketQua = 1;
      for (int i = 1; i <= y; i++)
      {
        ketQua = ketQua * x;
      }
      return ketQua;
    }   
    public static bool LaSoNguyenTo(int n)
    {
      if (n < 2) return false;
      for (int i = 2; i*i <=n; i++)
      {
        if (n % i == 0) return false;
      }
      return true;
    }

    public static void Run()
    {
      Console.WriteLine("Bai 2.3.3 Ket hop luy thua và so nguyn toos");
      Console.WriteLine("Cac sp nguyen to tu 2 đến 20 và binh phung cua chng: ");

      for (int i = 2; i <= 20; i++)
      {
        if (LaSoNguyenTo(i))
        {
          int binhPhuong = LuyThua(i, 2);
          Console.WriteLine($"So nguyen to: {i} và binh phong lad: {binhPhuong}");
        }
      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      Bai214.Run();

      Bai222.Run();
      Bai233.Run();
    }
  }
}
