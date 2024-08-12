using System;
using System.IO;
using System.Text;
using System.Diagnostics;

public class PasswordGenerator
{
    private static Random random = new Random();

    public static string GeneratePassword(int minLength, int maxLength, string allowedChars,
                                          int numberOfCharacters, string partialPassword = "",
                                          string priorityChars = "", bool useUpper = true,
                                          bool useLower = true, bool useDigits = true,
                                          bool useSpecialChars = true, string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?/`~")
    {
        int length = random.Next(minLength, maxLength + 1);
        StringBuilder password = new StringBuilder(length);
        StringBuilder availableChars = new StringBuilder(allowedChars);

        if (useLower)
            availableChars.Append("abcdefghijklmnopqrstuvwxyz");
        if (useUpper)
            availableChars.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        if (useDigits)
            availableChars.Append("0123456789");
        if (useSpecialChars && !string.IsNullOrEmpty(specialChars))
            availableChars.Append(specialChars);

        if (!string.IsNullOrEmpty(allowedChars))
            availableChars = new StringBuilder(allowedChars);

        if (!string.IsNullOrEmpty(priorityChars))
            availableChars.Insert(0, priorityChars);

        for (int i = 0; i < length; i++)
        {
            if (i < partialPassword.Length && partialPassword[i] != '_')
            {
                password.Append(partialPassword[i]);
            }
            else
            {
                password.Append(' ');
            }
        }

        for (int i = 0; i < length; i++)
        {
            if (password[i] == ' ')
            {
                password[i] = availableChars[random.Next(availableChars.Length)];
            }
        }

        char[] result = password.ToString().ToCharArray();
        Array.Sort(result, (x, y) => random.Next(-1, 2));
        return new string(result);
    }

    public static void GeneratePasswordsToFile(int numberOfPasswords, string filePath,
                                               int minLength, int maxLength,
                                               string allowedChars, int numberOfCharacters,
                                               string partialPassword = "", string priorityChars = "",
                                               bool useUpper = true, bool useLower = true,
                                               bool useDigits = true, bool useSpecialChars = true,
                                               string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?/`~")
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < numberOfPasswords; i++)
            {
                string password = GeneratePassword(minLength, maxLength, allowedChars, numberOfCharacters, partialPassword, priorityChars, useUpper, useLower, useDigits, useSpecialChars, specialChars);

                writer.WriteLine(password);
            }
        }
    }

    public static void Main(string[] args)
    {
        int numberOfPasswords = 100;

        string filePath = "passwords.txt";
        int minLength = 8;
        int maxLength = 12;


        string allowedChars = "1q2wQwerty!;_";
        string partialPassword = "1q2w____";
        string priorityChars = "1q2wQwerty!;_";

        bool useUpper = false;
        bool useLower = false;
        bool useDigits = false;
        bool useSpecialChars = false;

        string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?/`~";

        Console.WriteLine("Заданные параметры:");
        Console.WriteLine("Кол-во паролей - " + numberOfPasswords);
        Console.WriteLine("Длина паролей - от " + minLength + " до " + maxLength);
        if (allowedChars != "") Console.WriteLine("Символы для генерации - " + allowedChars);
        if (partialPassword != "") Console.WriteLine("Частичный ввод - " + partialPassword);
        if (priorityChars != "") Console.WriteLine("Приоритетные символы - " + priorityChars);
        Console.WriteLine("Заглавные символы - " + useUpper.ToString());
        Console.WriteLine("Строчные символы - " + useLower.ToString());
        Console.WriteLine("Цифры - " + useDigits.ToString());
        Console.WriteLine("Спец. символы - " + useSpecialChars.ToString());
        if(useSpecialChars) Console.WriteLine("Варианты спец. символов - " + specialChars);

        Console.WriteLine("\n");

        long memoryBefore = GC.GetTotalMemory(true);
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        GeneratePasswordsToFile(numberOfPasswords, filePath, minLength, maxLength, allowedChars, numberOfPasswords, partialPassword, priorityChars, useUpper, useLower, useDigits, useSpecialChars, specialChars);
        stopwatch.Stop();
        TimeSpan ts = stopwatch.Elapsed;
        long memoryAfter = GC.GetTotalMemory(true);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Время выполнения: {ts.TotalMilliseconds} мс");
        Console.WriteLine($"Использование памяти: {memoryAfter - memoryBefore} байт");
        Console.ResetColor();

        Console.WriteLine("\n");

        Console.WriteLine($"Сгенерировано {numberOfPasswords} паролей и сохранено в файл {filePath}");
        Console.WriteLine("Нажмите любую кнопку для продолжения...");
        Console.ReadKey();
    }
}