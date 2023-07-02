using Booklist.main.Data;
using System.Windows.Input;

namespace Booklist.main.Pages;

public partial class BookListPage : ContentPage
{
    private readonly BookRepository bookRepository;

    // public ICommand TestCommand { get; private set; }

    public BookListPage(BookRepository bookRepository)
	{
		InitializeComponent();

        this.bookRepository = bookRepository;
    }

    protected override async void OnAppearing()
    {
        this.collectionView.ItemsSource = await this.bookRepository.GetAllBooks();
    }
}