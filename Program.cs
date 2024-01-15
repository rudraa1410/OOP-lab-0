using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Task 1: Creating Variables
        int lowNumber = GetPositiveIntegerInput("Enter the low number: ");
        int highNumber = GetIntegerInputGreaterThan("Enter the high number: ", lowNumber);

        int difference = highNumber - lowNumber;
        Console.WriteLine($"The difference between {lowNumber} and {highNumber} is: {difference}");

        // Task 2: Looping and Input Validation
        lowNumber = GetPositiveIntegerInputWithLoop("Enter the low number: ");
        highNumber = GetIntegerInputGreaterThanWithLoop("Enter the high number: ", lowNumber);

        // Task 3: Using Arrays and File I/O
        int[] numbersArray = GenerateNumbersArray(lowNumber, highNumber);
        WriteNumbersToFile("numbers.txt", numbersArray);

        // Additional Tasks
        List<double> numbersList = GenerateNumbersList(lowNumber, highNumber);

        // Read numbers back from the file
        List<int> readNumbers = ReadNumbersFromFile("numbers.txt");

        // Print sum of numbers read from the file
        Console.WriteLine($"Sum of numbers read from the file: {SumOfNumbers(readNumbers)}");

        // Print prime numbers between low and high
        PrintPrimeNumbers(lowNumber, highNumber);
    }

    static int GetPositiveIntegerInput(string prompt)
    {
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0)
        {
            Console.Write("Please enter a positive integer: ");
        }
        return number;
    }

    static int GetIntegerInputGreaterThan(string prompt, int minValue)
    {
        int number;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out number) || number <= minValue)
        {
            Console.Write($"Please enter a number greater than {minValue}: ");
        }
        return number;
    }

    static int GetPositiveIntegerInputWithLoop(string prompt)
    {
        int number;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);
        return number;
    }

    static int GetIntegerInputGreaterThanWithLoop(string prompt, int minValue)
    {
        int number;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out number) || number <= minValue);
        return number;
    }

    static int[] GenerateNumbersArray(int low, int high)
    {
        int[] numbersArray = new int[high - low + 1];
        for (int i = 0; i < numbersArray.Length; i++)
        {
            numbersArray[i] = low++;
        }
        return numbersArray;
    }

    static List<double> GenerateNumbersList(int low, int high)
    {
        List<double> numbersList = new List<double>();
        for (double i = low; i <= high; i++)
        {
            numbersList.Add(i);
        }
        return numbersList;
    }

    static void WriteNumbersToFile(string fileName, int[] numbers)
    {
        Array.Reverse(numbers);
        File.WriteAllLines("\"C:\\Users\\solan\\OneDrive - Southern Alberta Institute of Technology\\Sem-2\\Object-Oriented Programming 2 (CPRG-211-E)\\Program.cs\"", Array.ConvertAll(numbers, x => x.ToString()));
    }

    static List<int> ReadNumbersFromFile(string fileName)
    {
        List<int> numbers = new List<int>();
        string[] lines = File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            if (int.TryParse(line, out int num))
            {
                numbers.Add(num);
            }
        }
        return numbers;
    }

    static int SumOfNumbers(List<int> numbers)
    {
        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }
        return sum;
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }

    static void PrintPrimeNumbers(int low, int high)
    {
        Console.WriteLine($"Prime numbers between {low} and {high}:");
        for (int i = low; i <= high; i++)
        {
            if (IsPrime(i))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }
}