using Booklist.main.Pages;

namespace Booklist.main;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("details", typeof(BookDetailPage));
        Routing.RegisterRoute("admin", typeof(BookAdminPage));
        Routing.RegisterRoute("list", typeof(BookListPage));
        Routing.RegisterRoute("about", typeof(BookAboutPage));
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        this.shellTitelLabel.Text = Shell.Current?.CurrentItem.CurrentItem.Title;
    }
}