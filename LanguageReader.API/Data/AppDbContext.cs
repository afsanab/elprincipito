using Microsoft.EntityFrameworkCore;
using LanguageReader.API.Models;

namespace LanguageReader.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
}
