using System;
using System.Collections.Generic;

namespace _5._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            string comment = Console.ReadLine();
            List<string> comments = new List<string>();
            while (comment.ToLower() != "end of comments")
            {
                comments.Add(comment);
                comment = Console.ReadLine();
            }
            Console.WriteLine($"<h1> \n    {title} \n</h1>");
            Console.WriteLine($"<article> \n    {content} \n</article>");
            foreach (var item in comments)
            {
                Console.WriteLine($"<div> \n    {item} \n</div>");
            }
        }
    }
}
