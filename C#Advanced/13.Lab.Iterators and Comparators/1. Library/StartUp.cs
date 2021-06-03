using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2004, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2005, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library libraryTwo = new Library(bookOne, bookTwo, bookThree);
            foreach (var book in libraryTwo)
            {
                Console.WriteLine(book);
            }

        }
    }
}
