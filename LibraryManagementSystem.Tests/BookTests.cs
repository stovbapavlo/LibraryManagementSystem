using NUnit.Framework;

namespace LibraryManagementSystem.Tests
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void BookInitialization_ValidInput_Success()
        {
            // Arrange
            string title = "Test Book";
            string author = "Test Author";
            string genre = "Test Genre";
            int year = 2020;
            int pages = 300;
            bool isAvailable = true;
            int id = 1;

            // Act
            Book book = new Book(title, author, genre, year, pages, isAvailable, id);

            // Assert
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(genre, book.Genre);
            Assert.AreEqual(year, book.Year);
            Assert.AreEqual(pages, book.Pages);
            Assert.AreEqual(isAvailable, book.IsAvailable);
            Assert.AreEqual(id, book.Id);
        }
    }
}
