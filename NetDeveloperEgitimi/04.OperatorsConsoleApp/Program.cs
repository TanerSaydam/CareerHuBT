string name = "Taner";
string surname = "Saydam";  
//Taner Saydam;
string fullName = name + " " + surname;

int age = 10;
fullName = fullName + " " + age; //Taner Saydam 10

int a = 5;
int b = 3;
int c = a + b; //8

string d = a + b + fullName; //8 + "Taner Saydam 10" => "8Taner Saydam 10"

//fullName = fullName - b; //string değerler sadece toplama operatörü ile kullanılabilir

//Operatörler + - * / % ++ -- += -= *= /= %=

d = a + b / (a * b) + a + d;

//int[] numbers =new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//if(numbers % 2 == 0) //şu işlemi yap

a = a + 1; //5 + 1 = 6
a++; //5 + 1 = 6
a = a - 1; //5 - 1 = 4
a--; //5 - 1 = 4


a += 5; //5 + 5 = 10;
a -= 5; //5 - 5 = 0;

name += " " + surname; //Taner Saydam

DateTime date = DateTime.Now;

//Console.WriteLine(a + b - name);