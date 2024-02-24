using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            CommonAlgorithmsInProgramming.MainMethod();
            LinkedList.MainFunction();
            Stack.Method();
            Queue.Function();
            HashTable.Hash();
            Recursion.CountDown((double)8);
            Recursion.CountDown(8);
            Recursion.RecursiveMethodRecursionFunction();
            Sort.SortFunctions();
            Search.SearchMethods();
            Algo.UniqueFilteringWithHashTable();
            Algo.ValueCountingWithHashTable();
            Algo.FindMaxValueRecursively();
        }
    }

    class CommonAlgorithmsInProgramming
    {
        public static void MainMethod()
        {
            long number = GCD(60, 96); // should be 12
            Console.WriteLine(number);
            Console.WriteLine(GCD(20, 8)); // should be 4
            Console.WriteLine(GCD(8, 8)); // should be 8
            Console.WriteLine(GCD(11, 13)); // should be 1
            Console.WriteLine(GCD(13, 11)); // must be 1
        }

        static long GCD(long a, long b) // Euclid's algorithm.              // a = 11 // b = 13
        {
            long temp;
            while (b != 0)                                                  // 13 != 0          // 11 != 0         // 2 != 0         // 1 != 0
            {
                temp = a;                                                   // temp = 11        // temp = 13       // temp = 11      // temp = 2
                a = b; // we return a as we set a equal to b ahead of time  // a = 13           // a = 11          // a = 2          // a = 1
                b = temp % b; // or `b = temp % a`                          // b = 11 % 13 = 11 // b = 13 % 11 = 2 // b = 11 % 2 = 1 // b = 2 % 1 = 0
            }
            return a;
        }
    }

    class LinkedList
    {
        class Node
        {
            double data;
            Node? next;
            public Node(double data)
            {
                this.data = data; //or `SetData(data);`, not `SetData(this.data);`.
                this.next = null;
            }
            public double GetData()
            {
                return this.data; // or just `data`
            }
            public void SetData(double data)
            {
                this.data = data; // not just `data = data`
            }
            public Node? GetNext()
            {
                return this.next;
            }
            public void SetNext(Node? node)
            {
                this.next = node;
            }
        }
        class List
        {
            long count;
            Node? head;
            public List(Node? head = null)
            {
                this.head = head; // not just `head = head`
                this.count = 0;
            }
            public long GetCount()
            {
                return this.count;
            }
            public void Insert(double data) // insert a new node to the head node
            {
                Node newNode = new Node(data);
                newNode.SetNext(this.head);
                this.head = newNode;
                count += 1;
            }
            public Node? Find(double data) // find the first item node with a given data
            {
                Node? item = this.head;
                while (item is not null)
                {
                    if (item.GetData() == data)
                        return item;
                    else
                        item = item.GetNext();
                }
                return null;
            }
            public Node? DeleteAt(long index)
            {
                if (index > count - 1)
                    return null;
                if (index == 0)
                    this.head = this?.head?.GetNext(); // We use `this` to point to the current instance of the type.
                else
                {
                    int counter = 0;
                    Node? node = this.head;
                    while (counter < index - 1)
                    {
                        node = node?.GetNext();
                        counter++;
                    }
                    node?.SetNext(node.GetNext()?.GetNext());
                    this.count--;
                }
                return null;
            }

            // utility function to print the contents of the list
            public void DumpList()
            {
                Node? tempNode = this.head;
                while (tempNode is not null)
                {
                    Console.WriteLine("Node: {0}", tempNode.GetData());
                    tempNode = tempNode.GetNext();
                }
            }
            public Node? DeleteFirstOccurredNodeWithValueWithoutKeyIndex(double data)
            {
                if (Find(data) == this.head)
                {
                    this.head = this.head?.GetNext();
                }
                else
                {
                    Node? tempNode = this.head;
                    do
                    {
                        if (tempNode?.GetNext() == Find(data))
                        {
                            tempNode?.SetNext(Find(data)?.GetNext());
                            break;
                        }
                        tempNode = tempNode?.GetNext();
                    } while (tempNode is not null);
                }

                if (!(Find(data!) is null))
                    this.count--;
                return null;
            }

        }
        public static void MainFunction()
        {
            List itemList = new List();
            itemList.Insert(5);
            itemList.Insert(1);
            itemList.Insert(8);
            itemList.Insert(2);

            itemList.DumpList();
            itemList?.Find(5!)?.SetData(8!);

            Console.WriteLine();
            itemList?.DumpList();

            Console.WriteLine(itemList?.GetCount());
            Console.WriteLine("'" + itemList?.Find(8!) + "'");
            Console.WriteLine("'" + itemList?.Find(20!) + "'");
            Console.WriteLine(itemList?.Find(8!) is null ? "null" : itemList?.Find(8!)?.GetData());
            Console.WriteLine(itemList?.Find(20!) is not null ? itemList?.Find(20!)?.GetData() : "null");
            Console.WriteLine(itemList?.Find(8!)?.GetData());
            Console.WriteLine(itemList?.Find(8!)?.GetNext()?.GetData());
            //itemList?.Find(8!)?.SetNext(itemList.Find(2));
            Console.WriteLine();

            itemList?.Insert(0!);
            itemList?.Insert(1!);
            itemList?.DumpList();
            Console.WriteLine(itemList?.GetCount());
            Console.WriteLine(itemList?.Find(2!) == null ? "null" : itemList?.Find(2!)?.GetData());
            Console.WriteLine();

            itemList?.DeleteAt(2!);
            itemList?.DumpList();
            Console.WriteLine(itemList?.GetCount());
            Console.WriteLine(itemList?.Find(2!) != null ? itemList?.Find(2!)?.GetData() : "null");
            Console.WriteLine();

            itemList?.DeleteAt(0!);
            itemList?.DumpList();

            Console.WriteLine();
            itemList?.DeleteFirstOccurredNodeWithValueWithoutKeyIndex(8!);
            itemList?.DumpList();

            Console.WriteLine();
            itemList?.Find(1!)?.SetData(20!);
            itemList?.DeleteFirstOccurredNodeWithValueWithoutKeyIndex(1);
            itemList?.DumpList();
            Console.WriteLine();
            itemList?.DeleteFirstOccurredNodeWithValueWithoutKeyIndex(20);
            itemList?.DumpList();
        }
    }

    class Stack
    {
        ArrayList stack = new ArrayList();
        public void Push(object item)
        {
            stack.Add(item);
        }
        public object? Pop()
        {
            object? element = stack?[^1!];
            stack?.RemoveAt(stack.Count! - 1!);
            return element!;
        }
        public object? Peek()
        {
            return stack[^1!]!;
        }
        public static void Method()
        {
            Stack stack = new Stack();
            stack.Push(8);
            stack.Push(1);
            stack.Push(5);
            stack.Push(2);
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Peek());
            stack.Push(8);
            Console.WriteLine(stack.Peek());
            stack.Pop();
            stack.Pop();
            Console.WriteLine(stack.Peek());
        }
    }

    // We can use a regular array list as a queue but it's very inefficient to do so and
    // that's because removing items from the front of a list requires a big O of linear
    // time complexity as all the subsequent items have to be shifted down in their
    // slots when we do that.
    class Queue
    {
        LinkedList list = new LinkedList();

        List<object> queue = new List<object>();

        public void Enqueue(object item)
        {
            queue.Add(item);
        }
        public object? Dequeue()
        {
            object? item = queue[0];
            queue?.RemoveAt(0);
            return item;
        }
        public object Peek()
        {
            return queue[0];
        }
        public static void Function()
        {
            Queue queue = new Queue();
            queue.Enqueue(2);
            queue.Enqueue(5);
            queue.Enqueue(1);
            queue.Enqueue(8);
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Peek());
            queue.Enqueue(8);
            Console.WriteLine(queue.Peek());
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine(queue.Peek());
        }
    }

    class HashTable
    {
        // C# hashtables don't shrink; they only grow by doubling like in lists.
        public static void Hash()
        {
            Hashtable hashMap = new Hashtable()
            {
                ["key1"] = 1,
                ["key2"] = 2,
                ["key3"] = "three",
            };

            Console.WriteLine(hashMap);

            // Now we've printed out the contents. You can see that they're not stored
            // in any particular order. In this case, they happen to be listed in
            // reverse order that I added them in, but hash tables don't make any
            // guarantees about that. There's no way of knowing what order a hash
            // table is going to store the keys and the values in.
            foreach (var element in hashMap)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            // And it's also possible to build the hash table progressively since these
            // data structures can grow or shrink to fit the data that they contain.

            Hashtable hashTable = new Hashtable();
            hashTable[(long)1] = (double)1;
            hashTable.Add((long)5, (double)5);
            hashTable[(long)8] = (double)8;
            foreach (var item in hashTable)
                Console.WriteLine(item);
            Console.WriteLine();
            hashTable.Remove((long)5);
            foreach (var item in hashTable)
                Console.WriteLine(item);
            Console.WriteLine();

            Hashtable hash = new Hashtable() { };
            hash["key1"] = 1;
            hash.Add("key2", 2);
            hash["key3"] = "three";
            hash.Remove("key3");
            foreach (object item in hash)
                Console.WriteLine(item);
            Console.WriteLine(hash["key1"] is not null ? hash["key1"]?.ToString() : "null");
            Console.WriteLine(hash["key8"] is null ? "null" : hash[key: "key8"]?.ToString());
            hash["key2"] = 8;
            hash["key8"] = "K8";
            foreach (object item in hash)
                Console.WriteLine(item);
        }

        double[] dynamicArray = new double[] { }; // dynamic array
        long[] staticArray = new long[8]; // static array
    }

    class Recursion
    {
        public static void RecursiveMethodRecursionFunction()
        {
            Console.WriteLine("The number {0} raised to the power {1} will be: {2}", 1, 8, Power(1, 8));
            Console.WriteLine("The number {0} raised to the power {1} will be: {2}", 0, 0, Power(0, 0));
            Console.WriteLine("The number {0} raised to the power {1} will be: {2}", 8, 0, Power(8, 0));
            Console.WriteLine("The number {0} raised to the power {1} will be: {2}", 8, 2, Power(8, 2));
            Console.WriteLine("{0}! equals: {1}", 0, Factorial(0));
            Console.WriteLine("{0}! equals: {1}", 1, Factorial(1));
            Console.WriteLine("{0}! equals: {1}", 5, Factorial(5));
            Console.WriteLine("{0}! equals: {1}", 8, Factorial(8));
            Console.WriteLine("{0}th term of the Fibonacci sequence series is: {1}", 0, Fibonacci(0));
            Console.WriteLine("{0}th term of the Fibonacci sequence series is: {1}", 1, Fibonacci(1));
            Console.WriteLine("{0}th term of the Fibonacci sequence series is: {1}", 2, Fibonacci(2));
            Console.WriteLine("{0}th term of the Fibonacci sequence series is: {1}", 8, Fibonacci(8));
        }
        public static double Power(long num, long pwr)
        {
            if (pwr is 0)
                return 1;
            else
                return num * Power(num, pwr - 1);
        }
        static public double Factorial(long k)
        {
            if (k is 0)
                return 1;
            else
                return k * Factorial(k - 1);
        }
        public static double Fibonacci(long m)
        {
            if (m == 0 || m == 1)
                return m;
            else
                return Fibonacci(m - 1) + Fibonacci(m - 2);
        }
        public static void CountDown(double m)
        {
            if (m == 0)
            {
                Console.WriteLine("Done!");
                return;
            }
            else
            {
                Console.WriteLine(m);
                CountDown(m - 1);
            }
        }
        public static void CountDown(long m)
        {
            if (m == 0)
            {
                Console.WriteLine("Done!");
                return; // the call stack is being unwound after the final return statement
            }
            else
            {
                Console.WriteLine(m);
                CountDown(m - 1);
                Console.WriteLine('k');
            }
        }
        static public long FactorialNoRecursion(byte n) // long and hard readable code
        {
            if (n == 0)
                return 1;
            long value = 1;
            for (int i = n; i > 0; i--)
            {
                value *= i;
            }
            return value;
        }
        public static long RecursiveFactorial(byte n) // short and clean readable code
        {
            if (n == 0) // The breaking point condition that limites the method from calling itself.
                return 1;
            return n * RecursiveFactorial((byte)(n - 1));
        }

        public long FibonacciNumbersNoRecursion(short n) // not recursive but high performance
        {
            if (n < 2)
                return n;
            long[] f = new long[n + 1];
            f[0] = 0;
            f[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
        }
        public long FibonacciNumbersRecursive(int n) // recursive but very poor performance
        {
            if (n == 0 || n == 1) //satisfying condition
                return n;
            return FibonacciNumbersRecursive(n - 2) + FibonacciNumbersRecursive(n - 1);
        }

        private Dictionary<string, string> errors = new Dictionary<string, string>();
        private List<string> result = new List<string>();
        private void SearchForFiles(string path)
        {
            try
            {
                foreach (string fileName in Directory.GetFiles(path)) // gets all files in the current path
                {
                    result.Add(fileName);
                }
                foreach (string directory in Directory.GetDirectories(path)) // gets all folders in the current path
                {
                    SearchForFiles(directory); // Here the methods calls itself with a new parameter.
                }
            }
            catch (System.Exception ex)
            {
                errors.Add(path, ex.Message);
            }
        }
    }

    class Sort
    {
        public static void SortFunctions()
        {
            List<long> list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Unsorted list:");
            PrintArrayList(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Bubble Sort:");
            BubbleSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Merge Sort:");
            MergeSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Quick Sort:");
            QuickSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Heap Sort:");
            HeapSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Selection Sort:");
            SelectionSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Insertion Sort:");
            InsertionSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Shell Sort:");
            ShellSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Count Sort:");
            CountSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Radix Sort:");
            RadixSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Bucket Sort:");
            BucketSort(list);
            Console.WriteLine();

            list = new List<long>() { 2, 7, 3, 8, 1, 5, 4, 6 };
            Console.WriteLine("Sorted with Comb Sort:");
            CombSort(list);
            Console.WriteLine();
        }

        public static void CombSort(List<long> list)
        {
            int n = list.Count;
            int gap = n;
            double shrinkFactor = 1.3;
            bool swap = true;

            while (gap > 1 || swap)
            {
                // Update the gap size.
                gap = (int)(gap / shrinkFactor);
                if (gap < 1)
                {
                    gap = 1;
                }

                swap = false;

                // Compare and swap elements with a fixed gap.
                for (int i = 0; i + gap < n; i++)
                    if (list[i] > list[i + gap])
                    {
                        (list[i + gap], list[i]) = (list[i], list[i + gap]);
                        swap = true;
                        PrintArrayList(list);
                    }
            }
        }

        public static void BucketSort(List<long> list)
        {
            int n = list.Count;

            // Determine maximum and minimum values.
            long minValue = list.Min();
            long maxValue = list.Max();

            // Number of buckets.
            int bucketCount = (int)(maxValue - minValue) + 1;

            // Create buckets list.
            List<long>[] buckets = new List<long>[bucketCount];
            for (int i = 0; i < bucketCount; i++)
                buckets[i] = new List<long>();

            // Distribute elements into the buckets.
            for (int i = 0; i < n; i++)
            {
                int bucketIndex = (int)(list[i] - minValue);
                buckets[bucketIndex].Add(list[i]);
            }

            // Sort each bucket using insertion sort.
            for (int i = 0; i < bucketCount; i++)
            {
                buckets[i].Sort();
                PrintArrayList(buckets[i]);
            }

            // Concatenate the sorted buckets.
            int index = 0;
            for (int i = 0; i < bucketCount; i++)
                for (int j = 0; j < buckets[i].Count; j++)
                    list[index++] = buckets[i][j];

            PrintArrayList(list);
        }

        public static void RadixSort(List<long> list)
        {
            long max = list.Max();

            // Perform LSD radix sort.
            for (int exp = 1; max / exp > 0; exp *= 10)
                CountingSort(list, exp);
        }
        static void CountingSort(List<long> list, int exp)
        {
            int n = list.Count;
            List<long> sorted = new List<long>(); // an empty list
            sorted = new List<long>(new long[n]);
            int[] count = new int[10];

            // Count the occurrences of each digit.
            for (int i = 0; i < n; i++)
            {
                long digit = (list[i] / exp) % 10;
                count[digit]++;
            }

            // Calculate the cumulative count.
            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            // Build the sorted array.
            for (int i = n - 1; i >= 0; i--)
            {
                long digit = (list[i] / exp) % 10;
                sorted[count[digit] - 1] = list[i];
                count[digit]--;
                PrintArrayList(sorted);
            }

            // Copy the output array to the original list.
            for (int i = 0; i < n; i++)
                list[i] = sorted[i];
        }

        public static void CountSort(List<long> list)
        {
            int n = list.Count;
            long maxValue = default;
            long minValue = default;

            // Find the maximum and minimum values in the list.
            foreach (var num in list)
            {
                if (num > maxValue)
                    maxValue = num;
                if (num < minValue)
                    minValue = num;
            }

            // Initializing count list with zeros.
            List<long> countList = new List<long>(new long[maxValue - minValue + 1]);

            // Mapping each element of the list as an index of count list array.
            foreach (var num in list)
                countList[(int)(num - minValue)]++;

            // Calculating the prefix sum at every index of the count list.
            for (int j = 1; j < countList.Count; j++)
                countList[j] += countList[j - 1];

            // Creating a sorted list from the count list.
            List<long> sorted = new List<long>(new long[n]);
            for (int k = n - 1; k >= 0; k--)
            {
                sorted[(int)(countList[(int)(list[k] - minValue)] - 1)] = list[k];
                countList[(int)(list[k] - minValue)]--;
                PrintArrayList(sorted);
            }

            // Copying items from the sorted list to the actual lists.
            for (int k = 0; k < sorted.Count; k++)
                list[k] = sorted[k];
        }

        public static void ShellSort(List<long> list)
        {
            int n = list.Count;
            int gap = 1;

            // Choose the gap sequence (e.g., Knuth sequence).
            while (gap < n / 3)
                gap = 3 * gap + 1;

            while (gap >= 1)
            {
                for (int i = gap; i < n; i++)
                {
                    long temp = list[i];
                    int j = i;

                    // Shift elements that are far apart by the gap distance.
                    while (j >= gap && list[j - gap] > temp)
                    {
                        list[j] = list[j - gap];
                        j -= gap;
                    }
                    PrintArrayList(list);
                    list[j] = temp;
                }
                gap /= 3;
            }
        }

        public static void InsertionSort(List<long> list)
        {
            int n = list.Count;

            for (int i = 1; i < n; i++)
            {
                long key = list[i];
                int j = i - 1;

                // Move elements of arr[0..i-1] that are greater than they key to one position ahead of their current position.
                while (j >= 0 && list[j] > key)
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = key;

                PrintArrayList(list);
            }
        }

        public static void SelectionSort(List<long> list)
        {
            int n = list.Count;

            // one by one move the boundary of the unsorted subarray
            for (int i = 0; i < n - 1; i++)
            {
                // find the minimum element in the unsorted part of the array
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                    if (list[j] < list[minIndex])
                        minIndex = j;

                // swap the minimum element with the leftmost element of the unsorted part
                (list[i], list[minIndex]) = (list[minIndex], list[i]);

                PrintArrayList(list);
            }
        }

        public static void HeapSort(List<long> list)
        {
            int n = list.Count;

            // building max heap
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(list, n, i);

            // extracting elements from the max heap
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root (maximum element) to the end.
                (list[i], list[0]) = (list[0], list[i]);
                // Heapify the reduced heap.
                Heapify(list, i, 0);
            }
        }
        static void Heapify(List<long> list, int n, int rootIndex)
        {
            int largest = rootIndex; // initialize the largest as a root
            int left = 2 * rootIndex + 1; // a left child
            int right = 2 * rootIndex + 2; // a right child

            // if the left child is larger than the root
            if (left < n && list[left] > list[largest])
                largest = left;

            // if the right child is larger than the largest so far
            if (right < n && list[right] > list[largest])
                largest = right;

            // if the largest is not the root
            if (largest != rootIndex)
            {
                PrintArrayList(list);

                // swap the root with the largest element
                (list[largest], list[rootIndex]) = (list[rootIndex], list[largest]);

                // recursively heapify the affected sub-tree
                Heapify(list, n, largest);
            }
        }

        public static void QuickSort(List<long> list)
        {
            QuickSortRecursive(list, 0, list.Count - 1);
        }
        static void QuickSortRecursive(List<long> list, int first, int last)
        {
            if (first < last)
            {
                // calculate the split point
                int pivotIdx = Partition(list, first, last);

                // sorting two partitions
                QuickSortRecursive(list, first, pivotIdx - 1);
                QuickSortRecursive(list, pivotIdx + 1, last);
            }
        }
        static int Partition(List<long> list, int first, int last)
        {
            // choose by default first item as the pivot value
            long pivotValue = list[first];

            // establish the upper and lower indices
            int lower = first + 1;
            int upper = last;

            // searching for the crossing point
            bool cross = false;
            while (!cross)
            {
                // to advance the lower index
                while (lower <= upper && list[lower] <= pivotValue)
                    lower++;
                // to lower the upper index
                while (list[upper] >= pivotValue && upper >= lower)
                    upper--;
                PrintArrayList(list);
                // If two indexes cross, we found the split point.
                if (upper < lower)
                    cross = true;
                else
                    (list[upper], list[lower]) = (list[lower], list[upper]);
            }

            // When the split point is found, we exchange the pivot value.
            (list[upper], list[first]) = (list[first], list[upper]);

            return upper;
        }

        public static void MergeSort(List<long> list)
        {
            int m;
            if (list.Count > 1)
            {
                m = list.Count / 2;
                List<long> left = list[..m];
                List<long> right = list[m..];
                MergeSort(left);
                MergeSort(right);

                int l = 0; // left list index
                int r = 0; // right list index
                int k = 0; // merge list index

                // while there is content in both lists
                while (l < left.Count && r < right.Count)
                {
                    if (left[l] < right[r])
                    {
                        list[k] = left[l];
                        l++;
                    }
                    else
                    {
                        list[k] = right[r];
                        r++;
                    }
                    k++;
                }

                // if the left list still has values
                while (l < left.Count)
                {
                    list[k] = left[l];
                    l++;
                    k++;
                }
                // if the right list still has values
                while (r < right.Count)
                {
                    list[k] = right[r];
                    r++;
                    k++;
                }
                PrintArrayList(list);
            }
        }

        public static void BubbleSort(List<long> list)
        {
            bool swap;
            for (int k = 0; k < list.Count - 1; k++)
            {
                swap = false;
                for (int m = 0; m < list.Count - k - 1; m++)
                    if (list[m] > list[m + 1])
                    {
                        (list[m + 1], list[m]) = (list[m], list[m + 1]);
                        swap = true;
                    }

                // If no swap was made in the inner loop, then the list is already sorted.
                if (!swap)
                    break;
                PrintArrayList(list);
            }
        }

        static void PrintArrayList(List<long> list)
        {
            foreach (var item in list)
                Console.Write(item + " ");
            Console.WriteLine();
        }
    }

    class Search
    {
        public static void SearchMethods()
        {
            ArrayList array = new ArrayList() { 2.0, 7.0, 3.0, 8.0, 1.0, 5.0, 4.0, 6.0 };
            Console.WriteLine("Sequential Search:");
            Console.WriteLine(SequentialSearch(array, 8) is not null ? SequentialSearch(array, 8) : "null");
            Console.WriteLine(SequentialSearch(array, 0) is not null ? SequentialSearch(array, 0) : "null");
            Console.WriteLine();

            Console.WriteLine("Binary Search:");
            ArrayList list = new ArrayList() { 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0 };
            Console.WriteLine(BinarySearch(list, 6) is not null ? BinarySearch(list, 6) : "null");
            Console.WriteLine(BinarySearch(list, 0) is not null ? BinarySearch(list, 0) : "null");

            Console.WriteLine("Is the array list sorted:");
            Console.WriteLine(IsSorted(array) ? "Sorted: " + true : "Sorted: " + false);
            Console.WriteLine(IsSorted(list) ? "Sorted: " + true : "Sorted: " + false);

            Console.WriteLine(array.ToArray().Zip(array.ToArray().Skip(1), (current, next) => (double)current! <= (double)next!).All(x => x));
            Console.WriteLine(list.ToArray().Zip(list.ToArray().Skip(1), (current, next) => (double)current! <= (double)next!).All(x => x));
        }

        public static bool IsSorted(ArrayList array)
        {
            for (int i = 0; i < array.Count - 1; i++)
                if ((double)array[i]! > (double)array[i + 1]!)
                    return false;
            return true;
        }

        public static long? BinarySearch(ArrayList list, double elementItem)
        {
            int lowerIdx = 0;
            int upperIdx = list.Count - 1;

            while (lowerIdx <= upperIdx)
            {
                int midPoint = lowerIdx + (upperIdx - lowerIdx) / 2;

                if ((double)list[midPoint]! == elementItem)
                    return midPoint;
                else if (elementItem > (double)list[midPoint]!)
                    lowerIdx = midPoint + 1;
                else
                    upperIdx = midPoint - 1;
            }

            return null;
        }

        public static double? SequentialSearch(ArrayList array, double itemElement)
        {
            for (long k = 0; k < array.Count; k++)
                if (itemElement == (double)array[(int)k]!)
                    return k;
            return null;
        }
    }

    class Algo
    {
        public static void FindMaxValueRecursively() // global function
        {
            List<double> array = new List<double>() { 2, 7, 3, 8, 1, 5, 4, 6 };

            Console.WriteLine(FindMax(array));

            double FindMax(List<double> array)
            {
                Range range = 1..;
                Index index = 0;

                if (array.Count == 1)
                    return array[index];

                double op1 = array[index];
                double op2 = FindMax(array[range]);

                if (op1 > op2)
                    return op1;
                else
                    return op2;
            }
        }

        public static void UniqueFilteringWithHashTable()
        {
            ArrayList array = ["carrot", "cabbage", "onion", "tomato", "potato", "apple", "pineapple", "carrot", "apple", "onion", "cabbage", "pumpkin", "cucumber"];
            foreach (object element in array)
                Console.WriteLine(element);
            Console.WriteLine();

            Hashtable table = new Hashtable();
            foreach (string element in array)
                table[element] = 0;

            HashSet<string> set = new HashSet<string>(table.Keys.Cast<string>());
            foreach (string key in set)
                Console.WriteLine(key);

            Console.WriteLine();

            List<string> list = ["carrot", "cabbage", "onion", "tomato", "potato", "apple", "pineapple", "carrot", "apple", "onion", "cabbage", "pumpkin", "cucumber"];
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine();

            Dictionary<string, sbyte> dictionary = new Dictionary<string, sbyte>();
            foreach (string item in list)
                dictionary[item] = 0;

            HashSet<string> hash = new HashSet<string>(dictionary.Keys);
            foreach (string value in hash)
                Console.WriteLine(value);
        }
        public static void ValueCountingWithHashTable()
        {
            List<string> list = ["carrot", "cabbage", "onion", "tomato", "potato", "apple", "pineapple", "carrot", "apple", "onion", "cabbage", "pumpkin", "cucumber"];
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine();

            Hashtable hashTable = new Hashtable();

            foreach (var item in list)
            {
                if (hashTable.ContainsKey(item))
                    hashTable[item] = (long)hashTable[item]! + 1;
                else
                    hashTable[item] = (long)1;
            }

            foreach (DictionaryEntry item in hashTable) // The DictionaryEntry type is a non-generic type of KeyValuePair.
            {
                Console.WriteLine($"[{item.Key}, {item.Value}]");
            }

            SortedList<double, long> GenericSortedList = new SortedList<double, long>() { }; // local variable
        }
        SortedList SortedList = new SortedList() { }; // global variable
    }
}