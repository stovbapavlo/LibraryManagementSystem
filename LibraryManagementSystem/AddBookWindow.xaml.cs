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

                // Створюємо рядок для збереження у файлі з включеним ID
                string line = $"{id};{title};{author};{genre};{year};{pages};{isAvailable}";

                // Зберігаємо рядок у файлі LibraryBooks.txt
                using (StreamWriter wr = new StreamWriter("LibraryBooks.txt", true))
                {
                    wr.WriteLine(line);
                }

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
            return (int)(DateTime.UtcNow - new DateTime(2024, 1, 1)).TotalSeconds;
        }
    }
}
