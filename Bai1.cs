using System;

namespace LearnWithFastdoer
{
  public class Bai1
  {
    public static void Run()
    {
      // Bài 1.1.1
      Console.WriteLine("Bai 1.1.1: In thong tin gioi thieu ve C#");

      string nameLang = "Ngon ngu: C#";
      string nameDev = "Nha phat trien: Anders Hejlsberg";
      string platform = "Nen tang: .NET";
      string reason = "Li do nen hoc C#: ho tro lap trinh da nen tang";

      Console.WriteLine(nameLang);
      Console.WriteLine(nameDev);
      Console.WriteLine(platform);
      Console.WriteLine(reason);

      Console.WriteLine("=======================================================");

      // Bài 1.1.2
      Console.WriteLine("Bai 1.1.2: Bang dac diem dung/sai cua C#");

      bool oopLang = true;
      bool garbageCollector = true;
      bool multiOs = true;
      bool isObliWin = false;

      Console.WriteLine("{0,-70}{1}", "Dac diem", "Dung/Sai");
      Console.WriteLine("{0,-70}{1}", "C# co phai la ngon ngu OOP khong", oopLang);
      Console.WriteLine("{0,-70}{1}", "C# co co che Garbage Collector khong", garbageCollector);
      Console.WriteLine("{0,-70}{1}", "C# co the chay tren nhieu he dieu hanh khong", multiOs);
      Console.WriteLine("{0,-70}{1}", "C# co bat buoc chay tren Windows khong", isObliWin);

      Console.WriteLine("=======================================================");

      // Bài 1.2.1
      Console.WriteLine("Bai 1.2.1 - Chuong trinh Hello World");

      Console.WriteLine("Hello World");

      string myName = "Vo Ngoc Kim Nhi";
      Console.WriteLine("Ten cua toi: {0}", myName);

      Console.WriteLine("=======================================================");

      // Bài 1.3.1
      Console.WriteLine("Bai 1.3.1 - In thong tin ca nhan");

      Console.WriteLine("Ho va ten: Vo Ngoc Kim Nhi");
      Console.WriteLine("Ten lop hoc: FastdoProductGrowth");
      Console.WriteLine("Ngay bat dau hoc: 07/09/2026");

      Console.WriteLine("=======================================================");

      // Bài 1.3.2
      Console.WriteLine("Bai 1.3.2 - Phan biet hoa thuong");

      string name = "kim nhi";
      string Name = "KIM NHI";

      Console.WriteLine(name);
      Console.WriteLine(Name);

      Console.WriteLine("=======================================================");

      // Bài 1.4.1
      Console.WriteLine("Bai 1.4.1 - Lop HinhVuong");

      Retangle retangle = new Retangle();

      retangle.NhapCanh();
      retangle.TinhChuVi();
      retangle.TinhDienTich();
      retangle.Display();

      Console.WriteLine("=======================================================");

      // Bài 1.4.2
      Console.WriteLine("Bai 1.4.2 - Hai doi tuong HinhTron");

      HinhTron hinhTron = new HinhTron();

      hinhTron.r = 5;

      Console.WriteLine($"Ban kinh: {hinhTron.r}");
      Console.WriteLine($"Chu vi: {hinhTron.TinhChuVi()}");
      Console.WriteLine($"Dien tich: {hinhTron.TinhDienTich()}");
    }
  }

  class Retangle
  {
    double edge;

    public void NhapCanh()
    {
      edge = 5;
    }

    public double TinhChuVi()
    {
      return edge * 4;
    }

    public double TinhDienTich()
    {
      return edge * edge;
    }

    public void Display()
    {
      Console.WriteLine($"Canh la: {edge}");
      Console.WriteLine($"Chu vi la: {TinhChuVi()}");
      Console.WriteLine($"Dien tich la: {TinhDienTich()}");
    }
  }

  class HinhTron
  {
    public double r;

    public double TinhChuVi()
    {
      return 2 * r * 3.14;
    }

    public double TinhDienTich()
    {
      return r * r * 3.14;
    }
  }
}