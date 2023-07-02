using Booklist.main.Data;

namespace Booklist.main.Pages;

public partial class BookAdminPage : ContentPage
{
    private readonly BookRepository bookRepository;

    public BookAdminPage(BookRepository bookRepository)
	{
        InitializeComponent();

        this.bookRepository = bookRepository;
    }

    protected override async void OnAppearing()
    {
        this.collectionView.ItemsSource = await this.bookRepository.GetAllBooks();
    }

    protected async void OnBtnEditClicked(object sender, EventArgs args)
    {
        // await Navigation.PushAsync(new BookDetailPage());
        await Shell.Current.GoToAsync("details");
    }

    protected void OnBtnDeleteClicked(object sender, EventArgs args)
    {
        string s = string.Empty;
    }
}