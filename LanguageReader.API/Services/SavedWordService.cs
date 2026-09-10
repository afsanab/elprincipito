using Microsoft.EntityFrameworkCore;
using LanguageReader.API.Data;
using LanguageReader.API.Models;

namespace LanguageReader.API.Services;

public class SavedWordService : ISavedWordService
{
    private readonly AppDbContext _context;

    public SavedWordService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> WordExistsAsync(int wordId)
    {
        return await _context.Words.AnyAsync(w => w.Id == wordId);
    }

    public async Task<bool> BookExistsAsync(int bookId)
    {
        return await _context.Books.AnyAsync(b => b.Id == bookId);
    }

    public async Task<bool> IsDuplicateAsync(int wordId, int bookId)
    {
        return await _context.SavedWords
            .AnyAsync(sw => sw.WordId == wordId && sw.BookId == bookId);
    }

    public async Task<SavedWord> SaveWordAsync(int wordId, int bookId)
    {
        var savedWord = new SavedWord
        {
            WordId = wordId,
            BookId = bookId,
            DateSaved = DateTime.UtcNow
        };

        _context.SavedWords.Add(savedWord);
        await _context.SaveChangesAsync();

        return savedWord;
    }

    public async Task<IEnumerable<SavedWordDto>> GetAllSavedWordsAsync()
    {
        var savedWords = await _context.SavedWords
            .Include(sw => sw.Word)
            .Include(sw => sw.Book)
            .OrderByDescending(sw => sw.DateSaved)
            .ToListAsync();

        return savedWords.Select(sw => new SavedWordDto
        {
            Id = sw.Id,
            Word = sw.Word!.WordText,
            Definition = sw.Word!.Definition,
            Book = sw.Book!.Title,
            DateSaved = sw.DateSaved
        });
    }

    public async Task<bool> DeleteSavedWordAsync(int id)
    {
        var savedWord = await _context.SavedWords.FindAsync(id);
        
        if (savedWord == null)
        {
            return false;
        }

        _context.SavedWords.Remove(savedWord);
        await _context.SaveChangesAsync();
        
        return true;
    }
}
