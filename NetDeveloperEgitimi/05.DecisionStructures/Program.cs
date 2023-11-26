//Şart Blogları
//if(1 == 2 && 0 != 0 || 5 > 5)
//{

//}

int a = 5;
int b = 10;

//&& ve operatörü
//|| veya operatörü

if(b > a)
{
    Console.WriteLine("B rakamı a rakamından büyük");
}
else
{
    Console.WriteLine("B rakamı a rakamından büyük değil");
}

if (a == 5 || a < 6)
{
    
}else if(a < 10)
{

}else if(a < 15)
{
    
}
else
{

}

switch(a)
{
    case 5:
        Console.WriteLine("a rakamı 5");
        break;
    case 10:
        Console.WriteLine("a rakamı 10");
        break;
    case 15:
        Console.WriteLine("a rakamı 15");
        break;
    default:
        Console.WriteLine("a rakamı 5, 10 veya 15 değil");
        break;
}



//Array => Diziler []
//int[] numbers; //değer atanmadı || null || []
int[] numbers = {1,2,3,4, 5 }; //5 elemanlı bir dizi oluşturduk ve değerlerini atadık
int[] numbers2 = new int[5];
numbers2[0] = 1;
numbers2[1] = 2;
numbers2[2] = 3;
numbers2[3] = 4;
numbers2[4] = 5;


numbers[3] = 10;

//indexlerden bahsediliyorsa 0'dan başlar
//uzunluktan, karakter sayısından ya da sayıdan bahsediliyorsa 1'den başlar
//string name = "Taner";
//name.Length; //5


//Collection => Koleksiyonlar => Listeler
List<int> numbers3 = new() { 1,2,3, 4, 5 };
numbers3.Add(6);
numbers3.Add(7);
numbers3.Add(8);
numbers3.Add(9);
numbers3.Add(10);
numbers3.Remove(3);

//class User
//{
//    public string Name;
//}

//List<User> users = new();
//users.Add(new User() { Name = "Taner" });
//users.Add(new User() { Name = "Taner" });
//users.Add(new User() { Name = "Taner" });
//users.Add(new User() { Name = "Taner" });
//users.Add(new User() { Name = "Taner" });
//users.Add(new User() { Name = "Taner" });


var user = new { Name = "Taner", Surname = "Saydam" };

var users = new List<object>()
{
    new { Name = "Taner", Surname = "Saydam" },
    new { Name = "Tahir", Surname = "Saydam" },
    new { Name = "Toprak", Surname = "Saydam" },
    new { Name = "Volkan", Surname = "Saydam" },
    new { Name = "Ayşe", Surname = "Saydam" },
    new { Name = "Kemal", Surname = "Saydam" }
};

foreach(var item in users)
{
    Console.WriteLine(item); //object Object
}

for(int i = 0; i < users.Count; i++)
{
    Console.WriteLine(users[i]);
}

Console.ReadLine();