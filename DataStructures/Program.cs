using System;
namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ArrayClass.Arrays();
        }
    }
}

class ArrayClass
{
    // ehh
    public static void Arrays()
    {
        long[] perStudentPetCount = [0, 1, 2, 0, 1, 2, 0, 2, 8];
        long numOfStudents = perStudentPetCount.Length;
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
}