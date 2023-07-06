using Booklist.main.Data;
using Booklist.main.Pages;
using Booklist.main.ViewModels;
using Microsoft.Extensions.Logging;

namespace Booklist.main;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("fa-regular-400.ttf", "FontAwesome");
				fonts.AddFont("fa-solid-900.ttf", "FontAwesomeSolid");
            });

        //string dbPath = FileAccessHelper.GetLocalFilePath(AppDatabase.DbName);
        //builder.Services.AddSingleton<BookRepository>(s => ActivatorUtilities.CreateInstance<BookRepository>(s, dbPath));

        builder.Services.AddSingleton<BookAboutPage>();
        builder.Services.AddSingleton<BookAdminPage>();
        builder.Services.AddSingleton<BookListPage>();
        builder.Services.AddSingleton<BookDetailPage>();
        builder.Services.AddSingleton<BookRepository>();
        builder.Services.AddSingleton<IDatabase, Database>();
        builder.Services.AddSingleton<AdminViewModel>();
        builder.Services.AddSingleton<ListViewModel>();
        builder.Services.AddSingleton<BookViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}