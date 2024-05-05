using System;

// Власний клас винятку для невірного значення x або y
public class InvalidValueException : Exception
{
    public InvalidValueException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        try
        {
            // Зчитування значення x з клавіатури
            Console.WriteLine("Введіть значення x:");
            double x = double.Parse(Console.ReadLine());

            // Зчитування значення y з клавіатури
            Console.WriteLine("Введіть значення y:");
            double y = double.Parse(Console.ReadLine());

            // Перевірка на нуль у знаменнику
            if (x == 0 || y == 0)
            {
                throw new InvalidValueException("Значення x або y не можуть бути нульовими");
            }

            // Обчислення виразу
            double result = ((1 / (x * y)) + (1 / (x * x + 1))) * (x + y);

            // Виведення результату
            Console.WriteLine("Результат виразу: " + result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка формату числа. Введіть коректне число.");
        }
        catch (InvalidValueException ex)
        {
            Console.WriteLine("Помилка: " + ex.Message);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Помилка: Ділення на нуль.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Сталася помилка: " + ex.Message);
        }
    }
}

//______________________________task2_______________________________

using System;

// Клас, що представляє факультет
public class Faculty
{
    public string Name { get; set; }

    public event EventHandler FacultyDay;  // Подія "День факультету"

    public Faculty(string name)
    {
        Name = name;
    }

    // Метод для сповіщення про подію "День факультету"
    public void CelebrateFacultyDay()
    {
        Console.WriteLine($"Сьогодні відзначається День факультету {Name}!");
        OnFacultyDay();  // Виклик події
    }

    // Метод для виклику події "День факультету"
    protected virtual void OnFacultyDay()
    {
        FacultyDay?.Invoke(this, EventArgs.Empty);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення факультету
        Faculty faculty = new Faculty("Фізико-математичний");

        // Підписка на подію "День факультету"
        faculty.FacultyDay += Faculty_FacultyDayHandler;

        // Симулюємо відзначення Дня факультету
        faculty.CelebrateFacultyDay();
    }

    // Обробник події "День факультету"
    static void Faculty_FacultyDayHandler(object sender, EventArgs e)
    {
        Console.WriteLine("Ура! Сьогодні День факультету!");
    }
}
