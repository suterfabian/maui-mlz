using Booklist.main.Data;
using Booklist.main.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Booklist.test
{
    public class BookRepositoryTest : TestBase
    {
        private Book book;
        private int currentBookId = 0;

        [SetUp]
        public void Setup()
        {
            DateTime now = DateTime.Now;

            this.book = new Book
            {
                Id = 0,
                Title = "Test-Title",
                Subtitle = "Test-Subtitle",
                Author = "Test-Author",
                ISBN = "1-222-33333-4",
                Publisher = "Test-Publisher",
                Image = "",
                Rating = 7,
                CreateDate = now,
                ChangeDate = now
            };
        }

        [Test, Order(1)]
        public async Task TestSaveBook()
        {
            this.book.Id = 0;

            var provider = this.CreateProvider();
            var bookRepo = provider.GetRequiredService<BookRepository>();

            await bookRepo.SaveBook(this.book);

            List<Book> dbBookList = await bookRepo.GetAllBooks();

            Book dbBook = dbBookList.FirstOrDefault(b => b.Title == this.book.Title);

            // I know, it's a bit of hack... ;-)
            this.currentBookId = dbBook.Id;

            Assert.Multiple(() =>
            {
                Assert.NotNull(dbBook);

                Assert.That(dbBook.Title, Is.EqualTo(this.book.Title));
            });
        }

        [Test, Order(2)]
        public async Task TestDeleteBook()
        {
            var provider = this.CreateProvider();
            var bookRepo = provider.GetRequiredService<BookRepository>();

            this.book.Id = this.currentBookId;

            await bookRepo.DeleteBook(this.book);

            List<Book> dbBookList = await bookRepo.GetAllBooks();

            Book dbBook = dbBookList.FirstOrDefault(b => b.Title == this.book.Title);

            Assert.Multiple(() =>
            {
                Assert.IsNull(dbBook);
            });
        }

        protected override IServiceCollection AddServices(ServiceCollection serviceCollection)
        {
            return base.AddServices(serviceCollection)
                   .AddSingleton<BookRepository>()
                   .AddSingleton<IDatabase, Database>();
        }
    }
}