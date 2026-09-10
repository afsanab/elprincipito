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
        
        // Configure JSON options to be case-insensitive
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        
        var bookDtos = JsonSerializer.Deserialize<List<BookDto>>(jsonString, jsonOptions);
        
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

    public static void SeedWords(AppDbContext context)
    {
        if (context.Words.Any())
        {
            return; // Words already seeded
        }

        var words = new List<Word>
        {
            // Common vocabulary from El Principito
            new Word { WordText = "casa", Definition = "house", Language = "Spanish" },
            new Word { WordText = "niño", Definition = "boy, child", Language = "Spanish" },
            new Word { WordText = "príncipe", Definition = "prince", Language = "Spanish" },
            new Word { WordText = "estrella", Definition = "star", Language = "Spanish" },
            new Word { WordText = "planeta", Definition = "planet", Language = "Spanish" },
            new Word { WordText = "rosa", Definition = "rose", Language = "Spanish" },
            new Word { WordText = "flor", Definition = "flower", Language = "Spanish" },
            new Word { WordText = "zorro", Definition = "fox", Language = "Spanish" },
            new Word { WordText = "serpiente", Definition = "snake", Language = "Spanish" },
            new Word { WordText = "desierto", Definition = "desert", Language = "Spanish" },
            new Word { WordText = "agua", Definition = "water", Language = "Spanish" },
            new Word { WordText = "amigo", Definition = "friend", Language = "Spanish" },
            new Word { WordText = "cordero", Definition = "lamb", Language = "Spanish" },
            new Word { WordText = "caja", Definition = "box", Language = "Spanish" },
            new Word { WordText = "dibujo", Definition = "drawing", Language = "Spanish" },
            new Word { WordText = "aviador", Definition = "aviator, pilot", Language = "Spanish" },
            new Word { WordText = "avión", Definition = "airplane", Language = "Spanish" },
            new Word { WordText = "viaje", Definition = "trip, journey", Language = "Spanish" },
            new Word { WordText = "rey", Definition = "king", Language = "Spanish" },
            new Word { WordText = "volcán", Definition = "volcano", Language = "Spanish" },
            new Word { WordText = "baobab", Definition = "baobab tree", Language = "Spanish" },
            new Word { WordText = "puesta", Definition = "sunset", Language = "Spanish" },
            new Word { WordText = "sol", Definition = "sun", Language = "Spanish" },
            new Word { WordText = "noche", Definition = "night", Language = "Spanish" },
            new Word { WordText = "día", Definition = "day", Language = "Spanish" },
            new Word { WordText = "corazón", Definition = "heart", Language = "Spanish" },
            new Word { WordText = "secreto", Definition = "secret", Language = "Spanish" },
            new Word { WordText = "importante", Definition = "important", Language = "Spanish" },
            new Word { WordText = "invisible", Definition = "invisible", Language = "Spanish" },
            new Word { WordText = "ojos", Definition = "eyes", Language = "Spanish" }
        };

        context.Words.AddRange(words);
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
