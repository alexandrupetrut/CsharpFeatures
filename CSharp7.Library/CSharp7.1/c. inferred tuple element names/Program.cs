using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp7.Library.CSharp7._1.c._inferred_tuple_element_names
{
    public class Program
    {
        public class Book
        {
            public string Name;
            public string Author;
            public int Pages;
        }

        public static List<Book> Books = new List<Book>
        {
            new Book { Name = "Book 1", Author = "Author 2", Pages = 122 },
            new Book { Name = "Book 2", Author = "Author 3", Pages = 160 },
            new Book { Name = "Book 3", Author = "Author 1", Pages = 189 },
            new Book { Name = "Book 4", Author = "Author 1", Pages = 250 },
            new Book { Name = "Book 5", Author = "Author 2", Pages = 282 },
            new Book { Name = "Book 6", Author = "Author 3", Pages = 355 }
        };

        static void Main()
        {
            // old way
            var results = Books.Select(x => (Author: x.Author, Pages: x.Pages))
                               .OrderBy(x => x.Author)
                               .GroupBy(x => x.Author)
                               .Select(x => (author: x.Key, count: x.Count(), totalPages: x.Sum(y => y.Pages)));

            //new way
            var inferredTupleResults = Books.Select(x => (x.Author, x.Pages))
                                            .OrderBy(x => x.Author)
                                            .GroupBy(x => x.Author)
                                            .Select(x => (author: x.Key, count: x.Count(), totalPages: x.Sum(y => y.Pages)));
                         // for example here, instead of "author:" we can use just x.Key and the inferred name would be Key, but that's not what we want

            foreach (var r in results)
            {
                Console.WriteLine($"{r.author} wrote {r.count} books for a total of {r.totalPages} pages");
            }
        }
    }
}
