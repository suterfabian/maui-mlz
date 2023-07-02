namespace Booklist.main;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        base.OnNavigated(args);

        this.shellTitelLabel.Text = Shell.Current?.CurrentItem.CurrentItem.Title;
    }
}