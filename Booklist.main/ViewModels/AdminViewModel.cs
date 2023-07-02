using Booklist.main.Data;
using Booklist.main.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Booklist.main.ViewModels
{
    public class AdminViewModel : BaseViewModel
    {
        private readonly BookRepository bookRepository;
        public ICommand DetailPageCommand { get; set; }

        public Command GetBooksCommand { get; }

        // public int Id { get; set; }

        public AdminViewModel(BookRepository bookRepository) 
        {
            this.bookRepository = bookRepository;

            this.GetBooksCommand = new Command(async () => await this.GetBooksAsync());

            this.DetailPageCommand = new Command(this.OpenDetailPageCommand);
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

        protected void OpenDetailPageCommand()
        {
            // await Navigation.PushAsync(new BookDetailPage());
            //await Shell.Current.GoToAsync("details");

            string s = string.Empty;

            // return null;
        }

        

        //private List<Book> books;
        //public List<Book> Books
        //{
        //    get { return this.books; }
        //    set
        //    {
        //        this.SetValue(ref this.books, value);
        //        this.OnPropertyChanged(nameof(this.Books));
        //    }
        //}


        /*
        public BookViewModel(Book book)
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

        */








        //public string ProfileImage => IsFavorite ? "FavoriteProfile" : "NormalProfile";

        //public ImageSource ProfileImage
        //{
        //    get
        //    {
        //        if (IsFavorite)
        //        {
        //            return ImageSource.FromResource("ContactsBook.Assets.Images.FavoriteProfile.png");
        //        }
        //        return ImageSource.FromResource("ContactsBook.Assets.Images.NormalProfile.png");
        //    }
        //}
    }
}