using Booklist.main.ViewModels;

namespace Booklist.main.Pages;

public partial class BookAdminPage : ContentPage
{
    private readonly AdminViewModel adminViewModel;

    public BookAdminPage(AdminViewModel adminViewModel)
	{
        InitializeComponent();

        this.BindingContext = adminViewModel;

        this.adminViewModel = adminViewModel;
    }

    protected override async void OnAppearing()
    {
        await this.adminViewModel.GetBooksAsync();
    }
}