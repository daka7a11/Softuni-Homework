using System;
using System.Collections.Generic;

namespace _2._Articles
{
    public class Article
    {
        public Article(string title,string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Edit(string content)
        {
            this.Content = content;
        }
        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }
        public void Rename(string title)
        {
            this.Title = title;
        }
        public void Override()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ");
            Article article = new Article (input[0], input[1], input[2]);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                if (command[0].ToLower()=="edit")
                {
                    article.Edit(command[1]);
                }
                else if (command[0].ToLower() == "changeauthor")
                {
                    article.ChangeAuthor(command[1]);
                }
                else if (command[0].ToLower() == "rename")
                {
                    article.Rename(command[1]);
                }
            }
            article.Override();
        }
    }
}
