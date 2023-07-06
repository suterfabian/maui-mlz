using Booklist.main.Models;

namespace Booklist.main.ViewModels
{
    public class BookViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public BookViewModel() 
        {
            this.SetBookProperties(new Book());
        }

        public BookViewModel(Book book)
        {
            this.SetBookProperties(book);
        }

        private readonly BookViewModel bookViewModel;

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