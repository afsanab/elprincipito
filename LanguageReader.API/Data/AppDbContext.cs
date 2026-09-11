using Microsoft.EntityFrameworkCore;
using LanguageReader.API.Models;

namespace LanguageReader.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<Word> Words => Set<Word>();
    public DbSet<SavedWord> SavedWords => Set<SavedWord>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Add unique constraint on WordId + BookId combination
        // This prevents saving the same word from the same book twice at the database level
        modelBuilder.Entity<SavedWord>()
            .HasIndex(sw => new { sw.WordId, sw.BookId })
            .IsUnique()
            .HasDatabaseName("IX_SavedWords_WordId_BookId_Unique");
    }
}
