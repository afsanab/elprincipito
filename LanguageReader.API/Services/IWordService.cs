using LanguageReader.API.Models;

namespace LanguageReader.API.Services;

public interface IWordService
{
    Task<Word?> GetWordByTextAsync(string wordText);
}
