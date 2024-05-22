using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace LibraryManagementSystem
{
    public partial class SearchBooksWindow : Window
    {
        private List<Book> books = new List<Book>();

        public SearchBooksWindow()
        {
            InitializeComponent();
            books = LoadBooksFromFile();
        }

        private List<Book> LoadBooksFromFile()
        {
            List<Book> loadedBooks = new List<Book>();
            try
            {
                using (StreamReader reader = new StreamReader("LibraryBooks.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(';');
                        if (data.Length == 7)
                        {
                            int id = int.Parse(data[0]);
                            string title = data[1];
                            string author = data[2];
                            string genre = data[3];
                            int year = int.Parse(data[4]);
                            int pages = int.Parse(data[5]);
                            bool isAvailable = bool.Parse(data[6]);

                            Book book = new Book(title, author, genre, year, pages, isAvailable, id);
                            loadedBooks.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не вдалося завантажити дані: " + ex.Message);
            }
            return loadedBooks;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            List<Book> searchResults = books.Where(book =>
                book.Title.ToLower().Contains(searchText) || book.Author.ToLower().Contains(searchText)).ToList();

            SearchResultsListBox.ItemsSource = null;
            SearchResultsListBox.Items.Clear();

            if (searchResults.Count > 0)
            {
                SearchResultsListBox.ItemsSource = searchResults;
            }
            else
            {
                MessageBox.Show("Книгу не знайдено.");
            }
        }
    }
}
