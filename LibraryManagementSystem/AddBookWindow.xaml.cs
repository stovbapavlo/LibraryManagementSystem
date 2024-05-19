using System;
using System.IO;
using System.Windows;

namespace LibraryManagementSystem
{
    public partial class AddBookWindow : Window
    {
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                string author = txtAuthor.Text;
                string genre = txtGenre.Text;
                int year = int.Parse(txtYear.Text);
                int pages = int.Parse(txtPages.Text);
                bool isAvailable = chkAvailable.IsChecked ?? false;
                int id = GenerateUniqueId(); // Генеруємо унікальний ID

                // Створюємо новий об'єкт книги і додаємо його до бібліотеки
                Book newBook = new Book(title, author, genre, year, pages, isAvailable, id);
                Library.Instance.AddBook(newBook);

                MessageBox.Show("Книга збережена успішно.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при збереженні книги: " + ex.Message);
            }
        }

        private int GenerateUniqueId()
        {
            // Можете реалізувати свій механізм генерації унікального ID
            // Наприклад, можна використовувати дату та час як унікальний ідентифікатор
            return (int)(DateTime.UtcNow - new DateTime(2020, 1, 1)).TotalSeconds;
        }
    }
}
