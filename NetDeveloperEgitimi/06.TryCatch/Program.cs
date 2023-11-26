

#region Örnek İsim
Console.WriteLine("Hello, World!");
try
{
    int a = 0;
    int b = 0;
    int c = a / b;
    Console.WriteLine(c);

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message); //son kullanıcı için
    Console.WriteLine(ex.StackTrace); //bu bizim için
}
finally
{
    Console.WriteLine("Finally bloğu çalıştı");
}
#endregion

Console.WriteLine("Finally bloğu çalıştı");

Console.ReadLine();

