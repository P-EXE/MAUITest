using MAUITest.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUITest.DataContext;

public class LocalDBContext : DbContext
{
  public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();

  public LocalDBContext(DbContextOptions<LocalDBContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    builder.Entity<ToDoItem>(t =>
    {
      t.HasKey(t => t.Id);
    });
  }
}