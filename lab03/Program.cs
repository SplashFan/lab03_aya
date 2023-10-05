/*Задание№1
Создайте структуру Vector с тремя полями X, Y и Z. 
Для созданной структуры переопределите операторы сложения векторов, 
умножения векторов, умножения вектора на число, а также логические операторы. 
Для логических операторов используйте сравнение по длине от начала координат.*/

Console.WriteLine("Задание 1\n");
Vector v1 = new Vector(1, 2, 3);
Vector v2 = new Vector(3, 2, 5);
Console.Write("v1 = ");
v1.print();
Console.Write("v2 = ");
v2.print();
Console.Write("v1 + v2 = ");
Vector v3 = v1 + v2;
v3.print();
Console.WriteLine($"v1 * v2 = {v1 * v2}");
Console.Write("v1 * 6 = ");
Vector v4 = v1 * 6;
v4.print();
Console.WriteLine($"v1 < v2 {v1 < v2}");
Console.WriteLine($"v1 > v2 {v1 > v2}");

/*Задание№2
Создайте класс Car со свойствами Name, Engine, MaxSpeed. Переопределите оператор ToString() таким образом,
чтобы он возвращал название машины(Name). Реализуйте возможность сравнения объектов Car,
реализовав интерфейс IEquatable<Car>. 
Создайте класс CarsCatalog, содержащий коллекцию машин – элементов типа Car и переопределите для него индексатор
таким образом, чтобы он возвращал строку с названием машины и типом двигателя.*/

Console.WriteLine("Задание 2\n");
Car car1 = new Car("Лексус", "V8", 200);
Car car2 = new Car("Нисан", "V12", 220);
Car car3 = new Car("Ферари", "V12", 280);
Console.WriteLine(car1.ToString());
Console.WriteLine(car1.Equals(car1));
Console.WriteLine(car1.Equals(car2));
CarsCatalog catalog = new CarsCatalog(car1, car2, car3);
Console.WriteLine(catalog[2]);

/*Задание№3
Создайте базовый класс Currency со свойством Value. Создайте 3 производных от Currency класса – CurrencyUSD, 
CurrencyEUR и CurrencyRUB со свойствами, соответствующими обменному курсу. 
В каждом из производных классов переопределите операторы преобразования типов таким образом, 
чтобы можно было явно или неявно преобразовать одну валюту в другую по курсу, 
заданному пользователем при запуске программы.*/

Console.WriteLine("Задание 3\n");
Console.Write("Введите курс доллара к рублю: ");
int UsdToRub = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите курс евро к рублю: ");
int EurToRub = Convert.ToInt32(Console.ReadLine());
CurencyUSD usd = new CurencyUSD { Value = 1342 };
CurencyRUB rub1 = ((double)usd * UsdToRub);
Console.WriteLine($"Convert {usd.Value} USD to RUB: {rub1.Value}");
CurencyEUR eur1 = ((double)rub1 / EurToRub);
Console.WriteLine($"Convert {usd.Value} USD to EUR: {eur1.Value}");
CurencyEUR eur = new CurencyEUR { Value = 360 };
CurencyRUB rub2 = ((double)eur * EurToRub);
Console.WriteLine($"Convert {eur.Value} EUR to RUB: {rub2.Value}");
CurencyUSD usd2 = (double)eur * EurToRub / UsdToRub;
Console.WriteLine($"Convert {eur.Value} EUR to USD: {usd2.Value}");

struct Vector //Структура для первого задания
{
    public int X ; public int Y; public int Z;
    public double len
    {
        get
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }
    }
    public Vector (int x, int y, int z)
    {
        X = x; Y = y; Z = z;
    }
    public static Vector operator +(Vector v1, Vector v2)
    {
        return new Vector { X = v1.X + v2.X, Y = v1.Y + v2.Y, Z = v1.Z + v2.Z };
    }

    public static int operator * (Vector v1, Vector v2)
    {
        return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
    }

    public static Vector operator * (Vector v1, int smnum)
    {
        return new Vector { X = v1.X * smnum, Y = v1.Y * smnum, Z = v1.Z * smnum };
    }

    public static bool operator < (Vector v1, Vector v2)
    {
        return v1.len < v2.len;
    }

    public static bool operator > (Vector v1, Vector v2)
    {
        return v1.len > v2.len;
    }

    public static bool operator >=(Vector v1, Vector v2)
    {
        return v1.len >= v2.len;
    }

    public static bool operator <=(Vector v1, Vector v2)
    {
        return v1.len <= v2.len;
    }

    public void print()
    {
        Console.WriteLine($"({X}, {Y}, {Z})");
    }
}

interface IEquatable<T>
{
    bool Equals(T obj);
}
class Car : IEquatable<Car>  //Класс машин для второго задания
{
    public string Name;
    public string Engine;
    public int MaxSpeed;
    public Car (string name, string engine, int maxSpeed)
    {
        Name = name; Engine = engine; MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if ( Name == other.Name && Engine == other.Engine && MaxSpeed == other.MaxSpeed)
        {
            return true;
        }
        return false;
    }
}

class CarsCatalog  //Класс каталог машин для второго задания
{
    private Car[] cars;
    public CarsCatalog(params Car[] kars)
    {
        cars = kars;
    }

    public string this[int index]
    {
        get { return cars[index].Name + " " + cars[index].Engine; }
    }
}

class Curency
{
    public double Value;
}

class CurencyUSD : Curency
{
    public static implicit operator CurencyUSD(double num)
    {
        return new CurencyUSD { Value = num };
    }

    public static explicit operator double(CurencyUSD cur)
    {
        return cur.Value;
    }
}

class CurencyRUB : Curency
{
    public static implicit operator CurencyRUB(double num)
    {
        return new CurencyRUB { Value = num };
    }

    public static explicit operator double(CurencyRUB cur)
    {
        return cur.Value;
    }
}

class CurencyEUR : Curency
{
    public static implicit operator CurencyEUR(double num)
    {
        return new CurencyEUR { Value = num };
    }

    public static explicit operator double(CurencyEUR cur)
    {
        return cur.Value;
    }
}