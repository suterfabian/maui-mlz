using Booklist.main.ViewModels;

namespace Booklist.main.Pages;

public partial class BookListPage : ContentPage
{
    // private readonly BookRepository bookRepository;
    private readonly ListViewModel listViewModel;
    // public ICommand TestCommand { get; private set; }

    public BookListPage(ListViewModel listViewModel) // BookRepository bookRepository
    {
		InitializeComponent();

        this.BindingContext = listViewModel;

        this.listViewModel = listViewModel;
    }

    protected override async void OnAppearing()
    {
        // this.collectionView.ItemsSource = await this.bookRepository.GetAllBooks();
        await this.listViewModel.GetBooksAsync();
    }
}