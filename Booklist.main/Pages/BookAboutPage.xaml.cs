using Booklist.main.Data;
using Booklist.main.Models;

namespace Booklist.main.Pages;

public partial class BookAboutPage : ContentPage
{
    private readonly BookRepository bookRepository;

    public BookAboutPage(BookRepository bookRepository)
	{
		InitializeComponent();
        this.bookRepository = bookRepository;
    }

    public async void OnButtonTestClicked(object sender, EventArgs args)
    {
        Console.WriteLine("OnButtonTestClicked");
        DateTime now = DateTime.Now;

        Book book = new Book();
        book.Title = "Das Buch 2";
        book.Subtitle = "der Bücher";
        book.Author = "Kaspar";
        book.ISBN = "245314-134-34-143";
        book.Publisher = "Hallo Verlag";
        book.Image = "bild.png";
        book.Rating = 3;
        book.CreateDate = now;
        book.ChangeDate = now;

        await this.bookRepository.SaveBook(book);
    }
}