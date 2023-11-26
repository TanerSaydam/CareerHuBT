using System.Reflection;

namespace IleriSeviyeOrnek1;

internal class Program
{
    static void Main(string[] args)
    {
        string name = Console.ReadLine();
        Assembly assembly = Assembly.GetExecutingAssembly(); //mevcut projenin assemblyisini elde eder
        Type myClassType = assembly.GetTypes().Where(p=> p.Name == "MyClass").FirstOrDefault();
        object myClassInstance = Activator.CreateInstance(myClassType);

        MethodInfo sayHelloMethod = myClassType.GetMethod("SayHello");
        sayHelloMethod.Invoke(myClassInstance, new object[] { name });
        Console.ReadLine();
    }
}

public class MyClass
{
    public void SayHello(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}
