using LanguageReader.API.Models;
using System.Text.Json;

namespace LanguageReader.API.Data;

public static class DbSeeder
{
    public static void SeedBooks(AppDbContext context)
    {
        if (context.Books.Any())
        {
            return; // Database already seeded
        }

        // Read books from JSON file
        var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "books.json");
        var jsonString = File.ReadAllText(jsonPath);
        
        var bookDtos = JsonSerializer.Deserialize<List<BookDto>>(jsonString);
        
        if (bookDtos == null || !bookDtos.Any())
        {
            return;
        }

        var books = bookDtos.Select(dto => new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Language = dto.Language,
            Text = dto.Text
        }).ToList();

        context.Books.AddRange(books);
        context.SaveChanges();
    }

    private class BookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
