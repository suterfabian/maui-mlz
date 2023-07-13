using Booklist.main.Data;
using Booklist.main.Models;
using Booklist.main.Services;
using System.Windows.Input;

namespace Booklist.main.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public ICommand OnSaveClickedCommand { get; private set; }
        public ICommand OnNewClickedCommand { get; private set; }
        public ICommand OnDeleteClickedCommand { get; private set; }

        private readonly BookRepository bookRepository;

        public BookViewModel(BookRepository bookRepository)
        {
            this.bookRepository = bookRepository;

            this.OnSaveClickedCommand = new Command(async () => await OnBtnSaveClickedCommand());
            this.OnNewClickedCommand = new Command(async () => await OnBtnNewClickedCommand());
            this.OnDeleteClickedCommand = new Command(async () => await OnBtnDeleteClickedCommand());
            
            this.SetBookProperties(new Book());
        }

        public void SetBookProperties(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Subtitle = book.Subtitle;
            this.Author = book.Author;
            this.ISBN = book.ISBN;
            this.Publisher = book.Publisher;
            this.Rating = book.Rating;
            this.CreateDate = book.CreateDate;
            this.ChangeDate = book.ChangeDate;
        }

        private Book GetBookWithProperties()
        {
            Book book = new Book
            {
                Id = this.Id,
                Title = this.title,
                Subtitle = this.subtitle,
                Author = this.author,
                ISBN = this.isbn,
                Publisher = this.publisher,
                Rating = this.rating,
                CreateDate = this.createDate,
                ChangeDate = this.changeDate
            };

            return book;
        }

        public async Task OnBtnSaveClickedCommand()
        {
            Book book = this.GetBookWithProperties();

            bool saveResult = await this.bookRepository.SaveBook(book);

            if (saveResult) await Shell.Current.GoToAsync("..");
            else DialogService.AlertAsync(this.bookRepository.StatusMessage);

            string s = string.Empty;
        }

        public async Task OnBtnNewClickedCommand()
        {
            DateTime now = DateTime.Now;

            Book newBook = new Book
            {
                Id = 0,
                Title = string.Empty,
                Subtitle = string.Empty,
                Author = string.Empty,
                ISBN = string.Empty,
                Publisher = string.Empty,
                Rating = 0,
                CreateDate = now,
                ChangeDate = now
            };

            this.SetBookProperties(newBook);
        }

        public async Task OnBtnDeleteClickedCommand()
        {
            bool result = await DialogService.ConfirmAsync("Wollen Sie dieses Element wirklich löschen?");

            if (result)
            {
                bool saveResult = await this.bookRepository.DeleteBook(this.GetBookWithProperties());

                if (saveResult) await Shell.Current.GoToAsync("..");
                else DialogService.AlertAsync("Beim Speichern des Buches ist ein Fehler aufgetreten!");
            }
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