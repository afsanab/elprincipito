using LanguageReader.API.Models;

namespace LanguageReader.API.Services;

public interface ISavedWordService
{
    Task<SavedWord> SaveWordAsync(int wordId, int bookId);
    Task<IEnumerable<SavedWordDto>> GetAllSavedWordsAsync();
    Task<bool> DeleteSavedWordAsync(int id);
    Task<bool> WordExistsAsync(int wordId);
    Task<bool> BookExistsAsync(int bookId);
    Task<bool> IsDuplicateAsync(int wordId, int bookId);
}

// DTO for returning saved words with related data
public class SavedWordDto
{
    public int Id { get; set; }
    public string Word { get; set; } = string.Empty;
    public string Definition { get; set; } = string.Empty;
    public string Book { get; set; } = string.Empty;
    public DateTime DateSaved { get; set; }
}
