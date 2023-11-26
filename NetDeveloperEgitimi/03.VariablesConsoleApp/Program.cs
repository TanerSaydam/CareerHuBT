Console.WriteLine("Hello, World!");


string name = "Taner Saydam"; //metinsel değerleri tutar
int age = 10; //tam sayı değerleri tutar -2milyar ile 2milyar arasında
bool isTrue = true; //true veya false değerleri tutar 0-1
DateTime date = DateTime.Now; //tarih ve saat değerleri tutar ay.gün.yıl saat:dakika:saniye
DateOnly dateOnly = DateOnly.FromDateTime(date); //sadece tarih değerleri tutar
TimeOnly timeOnly = TimeOnly.FromDateTime(date); //sadece saat değerleri tutar
decimal number = 100.10m; //virgüllü sayı değerleri tutar 18,18milyar ile 18,18milyar arasında
double number2 = 100.10; //virgüllü sayı değerleri tutar 18,18milyar ile 18,18milyar arasında
float number3 = 100.10f; //virgüllü sayı değerleri tutar 18,18milyar ile 18,18milyar arasında
long number4 = 100; //tam sayı değerleri tutar
object obj = new object(); //her türlü değeri tutar


string n1; //değer atanmadı || null
int a; //değer atanmadı || 0
bool b; //değer atanmadı || false;
decimal c; //değer atanmadı || 0
DateTime d; //değer atanmadı || 01.01.0001 00:00:00

//garbage collector - çöp toplayıcısı
//değer atanmayan değişkenlerin değerleri garbage collector tarafından temizlenir
//1000kb => 1byte yapar || 1000 byte => 1mb yapar || 1000mb => 1gb yapar || 1000gb => 1tb yapar