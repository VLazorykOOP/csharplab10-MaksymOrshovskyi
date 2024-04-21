using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Шлях до файлу
        string filePath = "text.txt";

        // Читання тексту з файлу
        string text = File.ReadAllText(filePath);

        // Створення стеку для зберігання голосних букв
        Stack<char> vowelsStack = new Stack<char>();

        // Перебір кожного символу тексту
        foreach (char c in text)
        {
            // Якщо символ є голосною буквою, додаємо його до стеку
            if (IsVowel(c))
            {
                vowelsStack.Push(c);
            }
        }

        // Виведення голосних букв у зворотньому порядку
        while (vowelsStack.Count > 0)
        {
            Console.Write(vowelsStack.Pop());
        }
    }

    // Метод для перевірки, чи є символ голосною буквою
    static bool IsVowel(char c)
    {
        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        return Array.IndexOf(vowels, c) != -1;
    }
}

