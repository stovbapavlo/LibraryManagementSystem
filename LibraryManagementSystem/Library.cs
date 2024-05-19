using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryManagementSystem
{
    class Library
    {
        private static Library instance;
        private List<Book> books = new List<Book>();

        // Забороняємо створення нових екземплярів класу через конструктор
        private Library() { }

        // Перевірка наявності єдиного екземпляру та створення його, якщо він відсутній
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

        public void AddBook(Book book)
        {
            books.Add(book);
            SaveBooksToFile();
        }

        public void RemoveBook(string title)
        {
            Book bookToRemove = books.FirstOrDefault(b => b.Title == title);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                SaveBooksToFile();
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        // Інші методи класу Library...

        private void SaveBooksToFile()
        {
            try
            {
                using (StreamWriter wr = new StreamWriter("LibraryBooks.txt"))
                {
                    foreach (Book book in books)
                    {
                        string line = $"{book.Title};{book.Author};{book.Genre};{book.Year};{book.Pages};{book.IsAvailable}";
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
