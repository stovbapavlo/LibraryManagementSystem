using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManagementSystem
{
    public partial class ShowBooksWindow : Window
    {
        private List<Book> books = new List<Book>();

        public ShowBooksWindow()
        {
            InitializeComponent();
            LoadBooksFromFile();
        }

        private void LoadBooksFromFile()
        {
            try
            {
                books.Clear(); 
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
                            books.Add(book);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load data: " + ex.Message);
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int bookId = (int)button.Tag;

            Book bookToEdit = books.FirstOrDefault(b => b.Id == bookId);
            if (bookToEdit != null)
            {
                UpdateBookWindow updateBookWindow = new UpdateBookWindow(bookToEdit);
                updateBookWindow.ShowDialog();

                BooksListBox.ItemsSource = null;
                BooksListBox.ItemsSource = books;
            }
            else
            {
                MessageBox.Show("Книгу не вдалося знайти для редагування.");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int bookId = (int)button.Tag;

            Book bookToRemove = books.FirstOrDefault(b => b.Id == bookId);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);

                BooksListBox.ItemsSource = null;
                BooksListBox.ItemsSource = books;

                Library.SaveBooksToFile(books);

                MessageBox.Show("Книгу видалено успішно.");
            }
            else
            {
                MessageBox.Show("Книгу не вдалося знайти для видалення.");
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BooksListBox.ItemsSource = books; 
        }
    }
}
