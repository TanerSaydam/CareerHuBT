using FluentValidation;
using System.Reflection;

namespace BasitOrnek1;

internal class Program
{
    static void Main(string[] args)
    {
        var assemblies = 
            Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(p=> p.Name == "Product")
            .ToList();

        foreach (var assembly in assemblies)
        {
            Console.WriteLine(assembly);
        }
        //Console.WriteLine("Hello, World!" + assembly.GetName().Name);
    }
}


public class User : Entity
{
    public string Name { get; set; }
}

public class Product
{

}


public class Entity
{

}
public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}