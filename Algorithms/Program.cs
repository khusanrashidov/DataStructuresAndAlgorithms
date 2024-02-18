using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");
            //CommonAlgorithmsInProgramming.MainMethod();
            //LinkedList.MainFunction();
            //Stack.Method();
            //Queue.Function();
            HashTable.Hash();
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
            foreach (object item in hash)
                Console.WriteLine(item);
        }

        double[] dynamicArray = new double[] { }; // dynamic array
        long[] staticArray = new long[8]; // static array
    }
}