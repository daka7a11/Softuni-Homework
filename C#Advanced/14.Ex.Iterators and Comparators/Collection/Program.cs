using System;
using System.Linq;

namespace Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] createCommand = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                ListyIterator<string> collection;
                if (createCommand.Length > 1)
                {
                    collection = new ListyIterator<string>(createCommand.Skip(1).ToList());
                }
                else
                {
                    collection = new ListyIterator<string>();
                }
                string input = Console.ReadLine().ToLower();
                while (input != "end")
                {
                    switch (input)
                    {
                        case "print":
                            collection.Print();
                            break;
                        case "hasnext":
                            Console.WriteLine(collection.HasNext());
                            break;
                        case "move":
                            Console.WriteLine(collection.Move());
                            break;
                        case "printall":
                            collection.PrintAll();
                            break;
                    }
                    input = Console.ReadLine().ToLower();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
