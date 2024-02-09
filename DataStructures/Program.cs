using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //ArrayClass.Arrays();
            //ArrayClass.MultiDimensionalArrays();
            //ArrayClass.JaggedArrays();
            //LinkedListClass.LinkedLists();
            //LinkedListClass.TravelBucketListUsingBuiltInLinkedList();
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
    public static void JaggedArrays()
    {
        long[][] jagged = new long[3][];

        // set row 0
        jagged[0] = new long[2];
        jagged[0][0] = 8;
        jagged[0][1] = 10;

        // set row 1
        jagged[1] = new long[8]; // Since we do not explicitly assign a value for the each item in the array, implicitly they are initialized to zero.

        // set row 2
        jagged[2] = new long[4] { 20, 40, 50, 80 }; // array collection initializer can be simplified

        Console.WriteLine("At row 2, column 0: " + jagged[2][0]);

        foreach (var element in jagged)
        {
            Console.WriteLine();
            foreach (var item in element)
                Console.Write(item + " "); // not + ' '
        }
    }
}

class LinkedListClass
{
    public static void LinkedLists()
    {
        LinkedListFromScratch myLinkedList = new LinkedListFromScratch();
        myLinkedList.Add(8); // current head is 8
        myLinkedList.Add(1); // now head is 1
        Console.WriteLine(myLinkedList.head.data);
        Console.WriteLine(myLinkedList.head.next.data);
    }

    static public void TravelBucketListUsingBuiltInLinkedList()
    {
        // creating linked list
        LinkedList<string> travelBucketList = new LinkedList<string>();

        // adding items
        travelBucketList.AddFirst("Osaka, Japan.");
        travelBucketList.AddFirst("Canberra, Australia.");
        travelBucketList.AddAfter(travelBucketList.First, "Paris, France.");
        travelBucketList.AddLast("Tokyo, Japan.");
        travelBucketList.AddBefore(travelBucketList.Last, "Roma, Italy.");
        foreach (var item in travelBucketList)
        {
            Console.WriteLine(item);
        }

        // We cannot apply indexing with [] to an expression of type 'LinkedList', however we can apply indexing with [] to type 'Array'.
        // We can only access items in the linked list by traversing from the front or rear of the linked list. Finding the first or last node is the most efficient way of accessing it. If we would access or search items using node index, then it would be inefficient. However, when we use Find or FindLast, we still traverse through the entire list from front or rear to retrieve specific item, which is also inefficient.

        // accessing items
        Console.WriteLine(travelBucketList.Find("Paris, France.")); // finds the first node that contains specified value
        Console.WriteLine(travelBucketList.FindLast("Roma, Italy.")); // finds the last node that contains specified value
        Console.WriteLine(travelBucketList.Find("Paris, France.").Value);
        Console.WriteLine(travelBucketList.FindLast("Roma, Italy.").ValueRef);
        Console.WriteLine(travelBucketList.Find("Paris, France.").Next);
        Console.WriteLine(travelBucketList.FindLast("Roma, Italy.").Previous.Value);
        Console.WriteLine(travelBucketList.Find("Osaka, Japan.").Next.Previous.Value);
        Console.WriteLine(travelBucketList.Find("Canberra, Australia.").Previous);
        Console.WriteLine(travelBucketList.Find("Kyoto, Japan."));
        //Console.WriteLine(travelBucketList.Find("Tokyo, Japan.").Next.Value); // will return null as last item points to the next item that is null

        // Searching to see our list contains the specified item is computationally expensive as we have to traverse thoroughly through the entire linked list.
        Console.WriteLine(travelBucketList.Contains("Osaka, Japan."));
        Console.WriteLine(travelBucketList.Contains("Kyoto, Japan."));
        Console.WriteLine(travelBucketList.Contains("Tokyo, Japan."));

        // removing items
        travelBucketList.RemoveFirst();
        travelBucketList.RemoveLast();

        // Removes the first occurrence of the specified item in the linked list and returns true if deleted; otherwise, it returns false.
        Console.WriteLine(travelBucketList.Remove("Kyoto, Japan."));
        Console.WriteLine(travelBucketList.Remove("Osaka, Japan."));

        travelBucketList.Clear(); // Removes all nodes of type 'LinkedListNode' from linked list type 'LinkedList'.

        // It should be noted that in a C# linked list, we can only find and remove items by object, not by index.
    }

    // classes are blueprints

    // Linked List
    class LinkedListFromScratch
    {
        public Node head;

        // methods are functions
        public void Add(long data)
        {
            if (this.head == null) // case when LL is empty
            {
                this.head = new Node(data);
            }
            else // case when LL is not empty
            {
                Node nodeToAdd = new Node(data); // newNode
                nodeToAdd.next = this.head; // newNode => currentHead
                this.head = nodeToAdd; // newHead => previousHead
            }
        }
    }

    // Instead of creating a linked list from scratch, we can use the LinkedList<T> C# class type.

    // Node
    class Node
    {
        public long data;
        public Node next;
        public Node(long data) => this.data = data;
    }
}

class StackClass
{
    // In C#, the ArrayList is a non-generic collection of objects whose size increases dynamically.
    // It is the same as Array except that its size increases dynamically.
    // An ArrayList can be used to add unknown data where you don't know the types and the size of the data.

    Array array = Array.CreateInstance(typeof(object), sizeof(double)); // Array.BinarySearch(array, 8) // static

    ArrayList arrayList = new ArrayList(); // arrayList.BinarySearch(8); // non-static

    // push function method
    public void Push(string item)
    {
        this.arrayList.Add(item); // A name can be simplified by removing an unnecessary 'this' keyword followed by a dot.
    }

    // pop function method
    public string? Pop()
    {
        if (this.arrayList.ToArray().Last() != null)
        {
            var lastItem = this.arrayList[^1];
            this.arrayList.RemoveAt(arrayList.ToArray().Length - 1);
            return (string?)lastItem;
        }
        return null;
    }

    // peek function method
    public string? Peek()
    {
        if (this.arrayList[^1] != null)
        {
            var lastItem = this.arrayList[^1];
            //this.arrayList.RemoveAt(arrayList.Count - 1);
            return (string?)lastItem;
        }
        return null;
    }
}