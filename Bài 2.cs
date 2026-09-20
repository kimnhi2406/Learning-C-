using System;

namespace LearnWithFastdoer
{
  public class Bai2
  {
    public static void Run()
    {
      // BAI 1.5.3
      Console.WriteLine("Bài 1.5.3 — Hien tuong tran so (overflow) khi vuot gioi han kieu");
     
      int max = 2147483647;
      max = max + 1;
      Console.WriteLine(max);

      int soLon = 300;
      byte b = (byte)soLon;
      Console.WriteLine(b);


      Console.WriteLine("==================================================================");


      // BAI 1.6.3
      Console.WriteLine("Bài 1.6.3 — Những cạm bẫy khi ép kiểu tường minh");

      double soThucAm = -5.9;
      int epKieu = (int)(-5.9);
      Console.WriteLine(epKieu); 
      // kết quả sẽ là -5, vì khi ép từ kiểu só thực sang số nguyên thì sẽ lấy phần nguyên của giá trị để hiển thị

      int soNguyen = 300;
      byte epSoNguyen = (byte)soNguyen;
      Console.WriteLine(epSoNguyen);
      // kết quả là 44 vì khi ép từ kiểu số nguyên qua byte với range giá trị lớn nhất là 255, thì bị vượt ngưỡng giá trị, nên C# sẽ tự động lấy phần dư của kết quả 300/256

      Console.WriteLine("Bài 1.7.3 — Hoán đổi giá trị 2 biến không dùng biến trung gian");
      int a = 5;
      int b1 = 10;
      Console.WriteLine($"a và b trước khi đổi: { a } và { b1}");
      a = b1;
      Console.WriteLine($"a sau khi đổi: {a}");
      b1 = 5;
      Console.WriteLine($"b sau khi đổi: {b1}");
      // có nhiều cách chỗ ni, ví dụ cộng thêm giá trị, cộng thêm vượt ngưỡng byte rồi ép kiểu để lấy dư,...

    }
  }
}