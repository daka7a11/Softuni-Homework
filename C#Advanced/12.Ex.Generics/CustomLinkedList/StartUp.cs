using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> intList = new DoublyLinkedList<int>();

            for (int i = 0; i < 3; i++)
            {
                intList.AddHead(i + 2);
            }

            for (int i = 0; i < 3; i++)
            {
                intList.AddLast(i + 1);
            }

            intList.ForEach(x => Console.WriteLine(x + " "));
            Console.WriteLine("----------");

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(intList.RemoveFirst());
            }

            Console.WriteLine("----------");

            DoublyLinkedList<string> stringList = new DoublyLinkedList<string>();

            for (int i = 0; i < 3; i++)
            {
                stringList.AddLast($"Gosho {i + 2}");
            }

            for (int i = 0; i < 3; i++)
            {
                stringList.AddLast($"Pesho {i + 1}");
            }

            stringList.ForEach(x => Console.WriteLine(x + " "));

            Console.WriteLine("----------");

            Console.WriteLine(string.Join('|', stringList.ToArray()));

            Console.WriteLine("----------");

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(stringList.RemoveFirst());
            }

            var list = new DoublyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddHead(i);
            }

            Console.WriteLine("NEW NEW NEW NEW");
            foreach (var item in list)
            {
                Console.WriteLine($"VALUE : {item.Value}");
            }
        }
    }
}
