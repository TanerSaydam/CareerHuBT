using Microsoft.AspNetCore.Mvc;

namespace WhatIsOOP.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase //Dependency Injection
{    
    [HttpPost]
    public IActionResult Create()
    {
        //request.Name = "Domates"; //recordlar değiştirilemezler.
        //Test test = new Test(); //istance türetme | örnek oluşturma | sınıfı neseye dönüştürme | classı objeye çevirme
        //test.Test2();

        //Test.Name = "Taner Saydam"; //newleme yapmadan class çağırabiliyoruz. bunlara static classlar deniyor. static  classlar bir defa instance oluştuktan sonra uygulama yaşam süresi boyunca hayatta kalırlar.


        StructProduct myStruct = new();
        myStruct.Name = "Taner Saydam";

        ClassProduct myClass = new();
        myClass.Name = "Taner Saydam";
        myClass.Price = 100;
        myClass.Stock = 50;
        myClass.Summary = "Taner Saydam'ın ürünü";        

        ClassProduct myClass2 = myClass;
        myClass2.Name = "Mahmut Demirkıran";

        StructProduct myStruct2 = myStruct;
        myStruct2.Name = "Mahmut Demirkıran";


       // IEntity entity = new();

        //Product product = new("Taner Saydam");
        //product.Name = "Domates";
        return NoContent();
    }
}

//public static class Test
//{
//    //public Test() //static bir class varsa constuctor yok demektir!!
//    //{ çünkü static class'lar newlenemez
//    //newleme yoksa constructor da yok demektir.

//    //}

//    public static string Name = "Taner Saydam";
//}


//class var static class
//record, struct

//public class Product
//{
//    public string Name { get; set; } = "Taner Saydam";
//}

//public record Product(string Name);



//class abstract class static class record stuct interface

public struct StructProduct
{
    public string Name { get; set; }
}

public interface IService
{
    void Create();
}

public abstract class Entity
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}
public class ClassProduct : Entity, IService //class bir yere dahil olursa ona inrehit denir. eğer interface bir yere dahil olursa ona implement denir. birden fazla inherit ve implement yapılamaz. 
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Summary { get; set; }
    public int Stock { get; set; }

    public void Create()
    {
        Console.WriteLine("Product a özel işlemler");
    }

    public int Topla(params int[] sayilar) //Topla(5); Topla(5,6,7);
    {
        int sonuc = 0;
        foreach (var item in sayilar)
        {
            sonuc += item;
        }
        return sonuc;
    }
}

public class Category : Entity, IService
{
    public void Create()
    {
        Console.WriteLine("Kategoriye özel işlemler");
    }
}
public class ShoppingCart : Entity, IService
{
    public void Create()
    {
        Console.WriteLine("Sepete özel işlemler");
    }
}
