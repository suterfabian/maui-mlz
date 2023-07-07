using Booklist.main.Data;
using Booklist.main.Models;
using System.Windows.Input;

namespace Booklist.main.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public ICommand OnSaveClickedCommand { get; private set; }
        public ICommand OnNewClickedCommand { get; private set; }
        public ICommand OnDeleteClickedCommand { get; private set; }

        public BookViewModel(BookRepository bookRepository)
        {
            this.SetBookProperties(new Book());
            this.bookRepository = bookRepository;
        }

        public BookViewModel(Book book)
        {
            this.SetBookProperties(book);
        }

        private readonly BookViewModel bookViewModel;
        private readonly BookRepository bookRepository;

        private void SetBookProperties(Book book)
        {
            this.Id = book.Id;
            this.title = book.Title;
            this.subtitle = book.Subtitle;
            this.author = book.Author;
            this.isbn = book.ISBN;
            this.publisher = book.Publisher;
            this.rating = book.Rating;
            this.createDate = book.CreateDate;
            this.changeDate = book.ChangeDate;

            this.OnSaveClickedCommand = new Command(async () => await OnBtnSaveClickedCommand());
            this.OnNewClickedCommand = new Command(async () => await OnBtnNewClickedCommand());
            this.OnDeleteClickedCommand = new Command(async () => await OnBtnDeleteClickedCommand());
        }

        public async Task OnBtnSaveClickedCommand()
        {
            string s = string.Empty;
        }

        public async Task OnBtnNewClickedCommand()
        {
            string s = string.Empty;
        }

        public async Task OnBtnDeleteClickedCommand()
        {
            string s = string.Empty;
        }

        private string title;
        public string Title
        {
            get { return this.title; }
            set
            {
                this.SetValue(ref this.title, value);
                this.OnPropertyChanged(nameof(this.Title));
            }
        }

        private string subtitle;
        public string Subtitle
        {
            get { return this.subtitle; }
            set
            {
                this.SetValue(ref this.subtitle, value);
                this.OnPropertyChanged(nameof(this.Subtitle));
            }
        }

        private string author;
        public string Author
        {
            get { return this.author; }
            set
            {
                this.SetValue(ref this.author, value);
                this.OnPropertyChanged(nameof(this.Author));
            }
        }

        private string isbn;
        public string ISBN
        {
            get { return this.isbn; }
            set
            {
                this.SetValue(ref this.isbn, value);
                this.OnPropertyChanged(nameof(this.ISBN));
            }
        }

        private string publisher;
        public string Publisher
        {
            get { return this.publisher; }
            set
            {
                this.SetValue(ref this.publisher, value);
                this.OnPropertyChanged(nameof(this.Publisher));
            }
        }

        private int rating;
        public int Rating
        {
            get { return this.rating; }
            set
            {
                this.SetValue(ref this.rating, value);
                this.OnPropertyChanged(nameof(this.Rating));
            }
        }

        private DateTime? createDate;
        public DateTime? CreateDate
        {
            get { return this.createDate; }
            set
            {
                this.SetValue(ref this.createDate, value);
                this.OnPropertyChanged(nameof(this.CreateDate));
            }
        }

        private DateTime? changeDate;
        public DateTime? ChangeDate
        {
            get { return this.changeDate; }
            set
            {
                this.SetValue(ref this.changeDate, value);
                this.OnPropertyChanged(nameof(this.ChangeDate));
            }
        }
    }
}