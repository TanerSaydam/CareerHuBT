namespace _02.ExampleChatConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sayı tahmini oyununa hoş geldiniz!");
            Random random = new Random();
            int targetNumber = random.Next(1,101);

            while (true)
            { 
                Console.WriteLine("Lütfen 1 ile 101 arasında bir sayı girin ve tuttuğum rakamı bulmaya çalışın");
                string input = Console.ReadLine();
                int myGuess = Convert.ToInt32(input);

                if (myGuess == targetNumber)
                {
                    Console.WriteLine("Tebrikler! Tuttuğum sayıyı bildiniz");
                    Console.ReadLine();
                    break;
                }
                else if(myGuess > targetNumber)
                {
                    if(myGuess - 1 == targetNumber)
                    {
                        Console.WriteLine("Neredeyde bildin. Sayıyı bence bir tane azalt");
                    }
                    else
                    {
                        Console.WriteLine("Tuttuğum sayıdan daha büyük bir tahminde bulundunuz");
                    }
                    
                }
                else if(myGuess < targetNumber)
                {
                    if(myGuess + 1 == targetNumber)
                    {
                        Console.WriteLine("Neredeyse bildin. Bence sayıyı bir arttır");
                    }
                    else
                    {
                        Console.WriteLine("Tuttuğum sayıdan daha küçük bir tahminde bulundunuz");
                    }                    
                }
            }        
        }
    }
}