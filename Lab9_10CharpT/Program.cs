using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Завдання 1: Реверс голосних букв

        // Шлях до файлу
        string vowelsFilePath = "text.txt";

        // Читання тексту з файлу
        string vowelsText = File.ReadAllText(vowelsFilePath);

        // Створення стеку для зберігання голосних букв
        Stack<char> vowelsStack = new Stack<char>();

        // Перебір кожного символу тексту
        foreach (char c in vowelsText)
        {
            // Якщо символ є голосною буквою, додаємо його до стеку
            if (IsVowel(c))
            {
                vowelsStack.Push(c);
            }
        }

        // Виведення голосних букв у зворотньому порядку
        Console.WriteLine("Завдання 1: Реверс голосних букв");
        while (vowelsStack.Count > 0)
        {
            Console.Write(vowelsStack.Pop());
        }
        Console.WriteLine("\n");
//_________________________________________________________________________________________________________
        // Завдання 2

        // Шлях до файлу з числами
        string numbersFilePath = "numbers.txt";

        // Читання чисел з файлу
        List<int> numbers = File.ReadAllLines(numbersFilePath)
                                 .Select(int.Parse)
                                 .ToList();

        // Задання інтервалу [a, b]
        int a = 5;
        int b = 10;

        // Створення стеків для зберігання чисел у відповідних групах
        Stack<int> inRangeStack = new Stack<int>();
        Stack<int> lessThanAStack = new Stack<int>();
        Stack<int> greaterThanBStack = new Stack<int>();

        // Розділення чисел на групи
        foreach (int num in numbers)
        {
            if (num >= a && num <= b)
            {
                inRangeStack.Push(num);
            }
            else if (num < a)
            {
                lessThanAStack.Push(num);
            }
            else
            {
                greaterThanBStack.Push(num);
            }
        }

        // Виведення елементів відповідно до порядку груп
        Console.WriteLine("Завдання 2: Каталог музичних дисків");
        Console.WriteLine("Numbers in the range [{0},{1}]:", a, b);
        while (inRangeStack.Count > 0)
        {
            Console.WriteLine(inRangeStack.Pop());
        }

        Console.WriteLine("Numbers less than {0}:", a);
        while (lessThanAStack.Count > 0)
        {
            Console.WriteLine(lessThanAStack.Pop());
        }

        Console.WriteLine("Numbers greater than {0}:", b);
        while (greaterThanBStack.Count > 0)
        {
            Console.WriteLine(greaterThanBStack.Pop());
        }
//_________________________________________________________________________________________________________
        // Завдання 3: 
        // Шлях до файлу
        string filePath = "text.txt";

        // Читання тексту з файлу
        string text = File.ReadAllText(filePath);

        // Створення списку для зберігання голосних букв
        VowelsList vowelsList = new VowelsList();

        // Додавання голосних букв у список
        foreach (char c in text)
        {
            if (IsVowel(c))
            {
                vowelsList.Add(c);
            }
        }

        // Виведення голосних букв у зворотньому порядку
        Console.WriteLine("Завдання 3: Реверс голосних букв з використанням ArrayList та інтерфейсів");
        vowelsList.ReversePrint();
    }

    // Метод для перевірки, чи є символ голосною буквою
    static bool IsVowel(char c)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        return Array.IndexOf(vowels, c) != -1;
    }
}

// Клас, який реалізує інтерфейси IEnumerable, IComparer і ICloneable
class VowelsList : IEnumerable, IComparer, ICloneable
{
    private ArrayList vowels = new ArrayList();

    // Метод для додавання голосної букви у список
    public void Add(char c)
    {
        vowels.Add(c);
    }

    // Метод для виведення голосних букв у зворотньому порядку
    public void ReversePrint()
    {
        for (int i = vowels.Count - 1; i >= 0; i--)
        {
            Console.Write(vowels[i]);
        }
    }

    // Реалізація інтерфейсу IEnumerable
    public IEnumerator GetEnumerator()
    {
        return vowels.GetEnumerator();
    }

    // Реалізація інтерфейсу IComparer
    public int Compare(object x, object y)
    {
        return ((char)x).CompareTo((char)y);
    }

    // Реалізація інтерфейсу ICloneable
    public object Clone()
    {
        VowelsList newList = new VowelsList();
        foreach (char c in vowels)
        {
            newList.Add(c);
        }
        return newList;
    }

//_________________________________________________________________________________________________________
        // Завдання 3.1: 
class Program
{
    static void Main()
    {
        // Шлях до файлу
        string filePath = "numbers.txt";

        // Читання чисел з файлу
        List<int> numbers = new List<int>(Array.ConvertAll(File.ReadAllLines(filePath), int.Parse));

        // Задання інтервалу [a, b]
        int a = 5;
        int b = 10;

        // Створення ArrayList для зберігання чисел у відповідних групах
        NumberGroups numberGroups = new NumberGroups();

        // Додавання чисел до відповідних груп
        foreach (int num in numbers)
        {
            if (num >= a && num <= b)
            {
                numberGroups.AddToRange(num);
            }
            else if (num < a)
            {
                numberGroups.AddLessThanA(num);
            }
            else
            {
                numberGroups.AddGreaterThanB(num);
            }
        }

        // Виведення елементів відповідно до порядку груп
        numberGroups.PrintGroups();
    }
}

// Клас, який реалізує інтерфейси IEnumerable, IComparer і ICloneable
class NumberGroups : IEnumerable, IComparer, ICloneable
{
    private ArrayList rangeNumbers = new ArrayList();
    private ArrayList lessThanANumbers = new ArrayList();
    private ArrayList greaterThanBNumbers = new ArrayList();

    // Метод для додавання числа у групу [a, b]
    public void AddToRange(int num)
    {
        rangeNumbers.Add(num);
    }

    // Метод для додавання числа, меншого за a
    public void AddLessThanA(int num)
    {
        lessThanANumbers.Add(num);
    }

    // Метод для додавання числа, більшого за b
    public void AddGreaterThanB(int num)
    {
        greaterThanBNumbers.Add(num);
    }

    // Метод для виведення груп чисел
    public void PrintGroups()
    {
        Console.WriteLine("Numbers in the range [{0},{1}]:", 5, 10);
        PrintArrayList(rangeNumbers);
        
        Console.WriteLine("Numbers less than {0}:", 5);
        PrintArrayList(lessThanANumbers);
        
        Console.WriteLine("Numbers greater than {0}:", 10);
        PrintArrayList(greaterThanBNumbers);
    }

    // Метод для виведення ArrayList
    private void PrintArrayList(ArrayList list)
    {
        foreach (int num in list)
        {
            Console.WriteLine(num);
        }
    }

    // Реалізація інтерфейсу IEnumerable
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // Реалізація інтерфейсу IComparer
    public int Compare(object x, object y)
    {
        throw new NotImplementedException();
    }

    // Реалізація інтерфейсу ICloneable
    public object Clone()
    {
        throw new NotImplementedException();
    }

}
