using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Articles
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Override()
        {
            Console.WriteLine($"{Title} - {Content}: {Author}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numOfArticles = int.Parse(Console.ReadLine());
            List<Article> listOfArticles = new List<Article>(numOfArticles);
            for (int i = 0; i < numOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                Article currArticle = new Article(input[0], input[1], input[2]);
                listOfArticles.Add(currArticle);
            }
            string criteria = Console.ReadLine();
            if (criteria.ToLower() == "title")
            {
                listOfArticles = listOfArticles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria.ToLower() == "content")
            {
                listOfArticles = listOfArticles.OrderBy(x => x.Content).ToList();
            }
            else if (criteria.ToLower() == "author")
            {
                listOfArticles = listOfArticles.OrderBy(x => x.Author).ToList();
            }
            foreach (Article x in listOfArticles)
            {
                x.Override();
            }
        }
    }
}
