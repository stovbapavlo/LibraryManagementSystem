using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem
{
    public class Library
    {
        private static Library instance;
        private List<Book> books = new List<Book>();

        private Library()
        {
            instance = this;
        }

        public static Library Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Library();
                }
                return instance;
            }
        }

        public void UpdateBook(Book updatedBook)
        {
            Book bookToUpdate = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = updatedBook.Title;
                bookToUpdate.Author = updatedBook.Author;
                bookToUpdate.Genre = updatedBook.Genre;
                bookToUpdate.Year = updatedBook.Year;
                bookToUpdate.Pages = updatedBook.Pages;
                bookToUpdate.IsAvailable = updatedBook.IsAvailable;
                Library.SaveBooksToFile(books);
            }
        }

        public static void SaveBooksToFile(List<Book> books)
        {
            try
            {
                using (StreamWriter wr = new StreamWriter("LibraryBooks.txt"))
                {
                    foreach (Book book in books)
                    {
                        string line = $"{book.Id};{book.Title};{book.Author};{book.Genre};{book.Year};{book.Pages};{book.IsAvailable}";
                        wr.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save data: " + ex.Message);
            }
        }
    }
}
