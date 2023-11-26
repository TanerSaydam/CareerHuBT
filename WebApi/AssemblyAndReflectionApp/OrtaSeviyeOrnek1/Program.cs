using System.Reflection;

namespace OrtaSeviyeOrnek1;

public class MyClass
{
    public int MyProperty { get; set; }
    public void MyMethod()
    {
        Console.WriteLine("My Method!");
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public MyClass()
    {
        
    }
}
internal class Program
{
    static void Main(string[] args)
    {
        Type myClassType = typeof(MyClass); //reflection
        MemberInfo[] memberInfos= myClassType.GetMembers();
        foreach (var member in memberInfos)
        {
            Console.WriteLine($"{member.MemberType}: {member.Name}");
        }
        Console.ReadLine();
    }
}
