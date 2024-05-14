using CommunityToolkit.Maui;
using MAUITest.DataContext;
using MAUITest.Pages;
using MAUITest.ViewModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace MAUITest;

public static class MauiProgram
{
  public static MauiApp CreateMauiApp()
  {
    var builder = MauiApp.CreateBuilder();
    builder
      .UseMauiApp<App>()
      .UseMauiCommunityToolkit()
      .ConfigureFonts(fonts =>
      {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
      });

#if DEBUG
		builder.Logging.AddDebug();
#endif

    #region DataContext
    SqliteConnection sqliteConnection = new(Statics.LocalDBInMemConn);
    sqliteConnection.Open();
    builder.Services.AddDbContext<LocalDBContext>(options =>
      options.UseSqlite(sqliteConnection)
    );
    #endregion DataContext

    #region Pages
    builder.Services.AddTransient<ToDoListPage>();
    builder.Services.AddTransient<ToDoListVM>();

    builder.Services.AddTransient<CreateToDoPage>();
    builder.Services.AddTransient<CreateToDoVM>();
    #endregion Pages

    return builder.Build();
  }
}
