using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addBookWindow = new AddBookWindow();
            addBookWindow.Show();
        }

        private void ShowBooks_Click(object sender, RoutedEventArgs e)
        {
            ShowBooksWindow showBooksWindow = new ShowBooksWindow();
            showBooksWindow.Show();
        }
        private void SearchBooks_Click(object sender, RoutedEventArgs e)
        {
            SearchBooksWindow searchBooksWindow = new SearchBooksWindow();
            searchBooksWindow.Show();
        }



    }
}