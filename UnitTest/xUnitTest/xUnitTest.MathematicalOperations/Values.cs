namespace xUnitTest.MathematicalOperations;
public class Values
{
    public string FullName = "Taner Saydam";

    public int Age = 33;

    public DateOnly DateOfBirthDay = new(1989, 09, 03);

    public User User = new() { Id = 1, FullName = "Taner Saydam" };

    internal int Number = 10;

    public bool CheckNumberIfTheGreaterThanZero(int a)
    {
        if(a < 0)
        {
            throw new ArgumentException("Numara 0 dan küçük olamaz");
        }

        return true;
    }
}

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
}


public class ApplicationDbContext
{
    //connection bilgim filan

    public virtual bool Add(User user)
    {
        return true;
    }

    public virtual int SaveChanges()
    {
        return 1;
    }
}

public interface IUserRepository
{
    bool Add(string fullName);
}

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public bool Add(string fullName)
    {
        User user = new()
        {
            Id = 1,
            FullName = fullName,
        };
        _context.Add(user);

        return _context.SaveChanges() >= 1;
    }
}
