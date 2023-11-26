namespace _01.MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //21:16 'da görüşmek üzere

            string name = "Taner Saydam";
            int age = 10;
            bool isTrue = true;
            DateTime date = DateTime.Now;
            //DateTime dateUTC = DateTime.UtcNow; bunu bölge saati aldığı için kullanmıyoruz
            decimal number = 100.10m; // dobule decimal float


            string n1 = "10";
            int n2 = Convert.ToInt32(n1);

            string n3 = "Taner";
            int n4 = 0;
            bool result = int.TryParse(n3, out n4);



            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Hello, World!");
            Console.ReadLine();
        }
    }
}