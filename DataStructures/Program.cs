using System;
using System.ComponentModel;
namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //ArrayClass.Arrays();
            ArrayClass.MultiDimensionalArrays();
        }
    }
}

class ArrayClass
{
    public static void Arrays()
    {
        long[] perStudentPetCount = [0, 1, 2, 0, 1, 2, 0, 2, 8]; // or long[] perStudentPetCount = { 0, 1, 2, 0, 1, 2, 0, 2, 8 };
        long numOfStudents = perStudentPetCount.Length;

        //Console.WriteLine(perStudentPetCount[9]); // index out of range exception
        Console.WriteLine(perStudentPetCount[8]);
        Console.WriteLine(numOfStudents);

        long sum = 0;
        foreach (long individualPetCount in perStudentPetCount)
        {
            sum += individualPetCount;
        }
        Console.WriteLine(sum);

        long average = sum / numOfStudents;
        Console.WriteLine(average); // we get integer and this is good because we cannot have half of a pet
    }
    public static void MultiDimensionalArrays()
    {
        string[,] dinnerChoices = { { "Salad", "Soup", "Cheese Plate" }, { "Chicken", "Salmon", "Lasagna" } };
        int appIndex = 0;
        int mainDishIndex = 1;

        string firstApp = dinnerChoices[appIndex, 0];
        string secondApp = dinnerChoices[appIndex, 1];
        string thirdMainDish = dinnerChoices[mainDishIndex, 0];

        Console.WriteLine(firstApp);
        Console.WriteLine(secondApp);
        Console.WriteLine(thirdMainDish);

        dinnerChoices[mainDishIndex, 1] = "Steak";
        Console.WriteLine(dinnerChoices[mainDishIndex, 1]);

        foreach (var element in dinnerChoices)
        {
            Console.Write(element + ' ');
            //foreach (var item in element)
            //    Console.WriteLine(item);
        }
    }
}