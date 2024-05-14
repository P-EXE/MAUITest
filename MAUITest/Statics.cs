namespace MAUITest;

public static class Statics
{
  public static string LocalDBInMemConn = "DataSource=myshareddb;mode=memory;cache=shared";
  public static string LocalDBConn = $"Filename={Path.Combine(FileSystem.AppDataDirectory, "storage.db3")}";
}
