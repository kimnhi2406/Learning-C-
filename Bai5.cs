using System;

namespace LearnWithFastdoer
{
  public class Bai264
  {
    public static void DemXuatHien(string chuoiLon, string chuoiCon)
    {
      int soLan = 0;
      int index = 0;
      // IndexOf sẽ trả về index của lần xuất hiện đầu tiên của một chuỗi, bắt đầu tìm kiếm từ vị trí chỉ định
      while ((index = chuoiLon.IndexOf(chuoiCon, index)) != -1)
      {
        soLan = soLan + 1;
        index = index + chuoiCon.Length;
      }
      Console.WriteLine($"Số lần xuất hiện của chuỗi con trong chuỗi lớn là: {soLan} ");
    }
    public static void Run()
    {
      Console.WriteLine("Dem so lan xuat hien cua chuoi con");
      Console.WriteLine("Chuỗi abcabcabcabc và abc");
      DemXuatHien("abcabcabcabc", "abc");
      Console.WriteLine("Chuỗi aaaa và aa");
      DemXuatHien("aaaa", "aa");

      
    }
  }


  public class Bai254
  {
    public static void Run()
    {
      //int[][] array = {
      // new[] { 1, 2, 3},
      // new[] { 4, 5, 6},
      // new[] { 7, 8, 9}
      //};

      int[,] mang =
      {
        {1, 2, 3 },
        {4, 5, 6 },
        {7, 8, 9 }
      };
      int tongDuongCheoChinh = 0;
      int tongDuongCheoPhu = 0;
      // GetLength: trả về số lượng phần tử của từng chiều (số dòng hoặc số cột)
      for (int i = 0; i < 3; i++)
      {
        tongDuongCheoChinh = tongDuongCheoChinh + mang[i, i];
        tongDuongCheoPhu = tongDuongCheoPhu + mang[i, 3 - 1 - i];
      }
      Console.WriteLine($"Tong duong cheo chinh la: {tongDuongCheoChinh}");
      Console.WriteLine($"Tong duong cheo phu la: {tongDuongCheoPhu}");
      bool doiXung = true;
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          if (mang[i, j] != mang[j, i])
          {
            doiXung = false;
            break;
          }
         
        }
        if (!doiXung)
          break;
      }
      

      if (doiXung)
        Console.WriteLine("Có đối xứng");
      else
        Console.WriteLine("Không đối xứng");

    }

  }
  class Program
  {
    static void Main(string[] args)
    {
      Bai264.Run();
      Bai254.Run();
    }
  }
}
