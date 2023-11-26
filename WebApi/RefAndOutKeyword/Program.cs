public class Program
{
    public static void Main(string[] args)
    {
        int sayi = 10;

        ChangeNumber(ref sayi);

        Console.WriteLine(sayi);  //5   15

        Console.ReadLine();
    }

    public static void ChangeNumber(ref int num)
    {
        num = 15;
    }
}