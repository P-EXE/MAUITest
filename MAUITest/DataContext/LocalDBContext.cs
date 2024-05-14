using MAUITest.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUITest.DataContext;

public class LocalDBContext : DbContext
{
  public DbSet<ToDoTask> ToDoTasks => Set<ToDoTask>();

  public LocalDBContext(DbContextOptions<LocalDBContext> options) : base(options)
  {
    Database.EnsureCreated();
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);

    builder.Entity<ToDoTask>(t =>
    {
      t.HasKey(t => t.Id);
    });
  }
}