using Booklist.main.Data;
using Booklist.main.Models;
using System.Collections.ObjectModel;

namespace Booklist.main.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private readonly BookRepository bookRepository;

        public Command GetBooksCommand { get; }

        public ListViewModel(BookRepository bookRepository) 
        {
            this.bookRepository = bookRepository;

            this.GetBooksCommand = new Command(async () => await this.GetBooksAsync());
        }

        public ObservableCollection<Book> Books { get; } = new();

        public async Task GetBooksAsync()
        {
            List<Book> bookList = await this.bookRepository.GetAllBooks();

            if(this.Books.Count > 0) this.Books.Clear();

            foreach (var book in bookList)
            {
                this.Books.Add(book);
            }
        }
    }
}