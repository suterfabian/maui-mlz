using Booklist.main.Models;
using Booklist.main.ViewModels;

namespace Booklist.main.Pages;

[QueryProperty(nameof(BookToDisplay), "book")]
public partial class BookDetailPage : ContentPage
{
    private readonly BookViewModel bookViewModel;

    public BookDetailPage(BookViewModel bookViewModel)
	{
		InitializeComponent();

        BindingContext = bookViewModel;

        this.bookViewModel = bookViewModel;
    }

    Book bookToDisplay;
    public Book BookToDisplay
    {
        get => this.bookToDisplay;
        set
        {
            if (this.bookToDisplay == value)
                return;

            this.bookToDisplay = value;

            this.bookViewModel.SetBookProperties(value);

            //if (this.bookToDisplay != null)
            //    BindingContext = new BookViewModel(this.bookToDisplay);
        }
    }

    protected async void OnBtnBackClicked(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("..");
    } 
}