using Booklist.main.ViewModels;

namespace Booklist.main.Pages;

public partial class BookAdminPage : ContentPage
{
    // private readonly BookRepository bookRepository;
    private readonly AdminViewModel adminViewModel;

    public BookAdminPage(AdminViewModel adminViewModel) // BookRepository bookRepository
	{
        InitializeComponent();

        this.BindingContext = adminViewModel;

        // this.bookRepository = bookRepository;

        this.adminViewModel = adminViewModel;
    }

    protected override async void OnAppearing()
    {
        // this.collectionView.ItemsSource = await this.bookRepository.GetAllBooks();
        await this.adminViewModel.GetBooksAsync();
    }

    protected async void OnBtnEditClicked(object sender, EventArgs args)
    {
        // await Navigation.PushAsync(new BookDetailPage());
        //await Shell.Current.GoToAsync("details");

        string s = string.Empty;

        // return null;
    }

    protected void OnBtnDeleteClicked(object sender, EventArgs args)
    {
        string s = string.Empty;
    }
}