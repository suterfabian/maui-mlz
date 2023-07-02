namespace Booklist.main.Pages;

public partial class BookDetailPage : ContentPage
{
	public BookDetailPage()
	{
		InitializeComponent();
	}

    protected async void OnBtnBackClicked(object sender, EventArgs args)
    {
        // await Navigation.PushAsync(new BookDetailPage());
        await Shell.Current.GoToAsync("..");
    }
}
