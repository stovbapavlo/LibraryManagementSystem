using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        public bool IsAvailable { get; set; }
        public int Id { get; set; } 

        public Book(string title, string author, string genre, int year, int pages, bool isAvailable, int id)
        {
            Title = title;
            Author = author;
            Genre = genre;
            Year = year;
            Pages = pages;
            IsAvailable = isAvailable;
            Id = id;
        }
    }

}
