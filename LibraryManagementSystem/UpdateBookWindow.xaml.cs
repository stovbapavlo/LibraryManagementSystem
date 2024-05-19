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

            // Встановлюємо властивість BookToUpdate і прив'язуємо її до елементів керування
            BookToUpdate = book;
            DataContext = BookToUpdate;
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            // Зберігаємо зміни у списку книг
            Library.Instance.UpdateBook(BookToUpdate);

            // Закриваємо вікно
            Close();
        }
    }
}
