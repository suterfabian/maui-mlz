using Booklist.main.Data;
using System.Windows.Input;
using Booklist.main.Models;
using System.Collections.ObjectModel;

namespace Booklist.main.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly BookRepository bookRepository;

        public ICommand DetailPageCommand { get; set; }

        public Command GetBooksCommand { get; }

        public AdminViewModel(BookRepository bookRepository) 
        {
            this.bookRepository = bookRepository;

            this.GetBooksCommand = new Command(async () => await this.GetBooksAsync());

            this.DetailPageCommand = new Command<Book>(this.OpenDetailPageCommand);
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

        protected async void OpenDetailPageCommand(Book book) // Book book
        {
            if (book == null)
                return;

            var navigationParameter = new Dictionary<string, object>()
            {
                { "book", book }
            };

            await Shell.Current.GoToAsync("details", navigationParameter);
        }
    }
}