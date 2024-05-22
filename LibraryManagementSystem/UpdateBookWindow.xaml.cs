using System;
using System.Windows;

namespace LibraryManagementSystem
{
    public partial class UpdateBookWindow : Window
    {
        public Book BookToUpdate { get; set; }

        public UpdateBookWindow(Book book)
        {
            InitializeComponent();

            BookToUpdate = book;
            DataContext = BookToUpdate;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Library.Instance.UpdateBook(BookToUpdate);

            Close();
        }
    }
}
