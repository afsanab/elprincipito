using Microsoft.EntityFrameworkCore;
using LanguageReader.API.Data;
using LanguageReader.API.Models;

namespace LanguageReader.API.Services;

public class WordService : IWordService
{
    private readonly AppDbContext _context;

    public WordService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Word?> GetWordByTextAsync(string wordText)
    {
        return await _context.Words
            .FirstOrDefaultAsync(w => w.WordText.ToLower() == wordText.ToLower());
    }
}
