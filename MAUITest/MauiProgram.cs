using CommunityToolkit.Maui;
using MAUITest.DataContext;
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

    SqliteConnection sqliteConnection = new(Statics.LocalDBInMemConn);
    sqliteConnection.Open();
    builder.Services.AddDbContext<LocalDBContext>(options =>
      options.UseSqlite(sqliteConnection)
    );

    return builder.Build();
  }
}
