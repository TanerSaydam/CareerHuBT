Software Developer - .NET Uzmanıyım
## .NET Framework ve .NET Core arasındaki Fark
- Asp.NET => Web Sitesi (.NET'in Siteleri) => MVC, WEBAPI

## C# Dilinde Veri Tipleri ve Koleksiyonlar Nelerdir
- string, int, decimal(18,4), double, float, boolean, DateTime, DateOnly, TimeOnly, object, List, HashSet, IEnumerable, IQuerable, ICollection

Example: 4000000 => double, 4000000m => decimal
Example: TimeSpan => Bu Veri Tipi iki tarih arasındaki farkı hesaplamada kullanılır
Advanced Example: object a = 5, "Taner", true, {name = "Taner"} => (int)a; Convert.ToInt32(a);
Advanced Example: HashSet<string> names = new() {"Taner"}
Advanced Example: IEnumerable
[HttpPost]
public IActionResult Save(IEnumerable<string> names){
    //işleyim
}
Advanced Example: IQuerable
var users = context.Users.AsQuerable();
users.Where(p=> p.Id == 1).ToList();

## MVC (Model-View-Controller) tasarım deseni nedir

## Entity Framework Core Nedir ve Neden Kullanılır?

## ASP.NET Web API Nedir ve Ne İçin Kullanılır?

## Dependency Injection Nedir?
public class HomeController{
    AppDbContext _context = new(new DbOptionBuilder(){
        new DbOptions(){
            UseSqlServer("");
        }
    }); //newleyerek instance türetme

    public HomeController(AppDbContext context, IUserService userService){ //injection ile instance türetme
            _context = context;
    }
}

public interface IUserService{
    void Create(User user);
}

public class UserService : IUserService{
    public void Create(User user){
        //Create İşlemleri
    }
}

public class UserService2 : IUserService{
    public void Create(User user){
        //Başka Create İşlemleri
    }
}

public class AppDbContext{
    public AppDbContext(DbContextOptions options){

    }
}

IoC
builder.Service.AddScoped<AppDbContext>(options=> {
    options.UseSqlServer("");
});
builder.Service.AddScoped<IUserService,UserService2>();

## LINQ Nedir?
List<string> names = new();

names.Add("Taner"); => Bu bir linq işlemidir
names.ToList() => bu bir linq işlemidir
names.Where(p=> p == "Taner") => bu bir linq işlemidir
names.FirstOrDefault();

## Garbage Collection nedir?

## SOLID, YAGNI, KISS, DRY Prensipleri

public class A{
    public virtual void Method(){
        //a ya işlemler yapıyorum
    }
}


public class B : A{
  public ovveride void Method(){
    //B ye ait işlemler
  }
}