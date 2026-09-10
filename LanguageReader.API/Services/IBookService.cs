using LanguageReader.API.Models;

namespace LanguageReader.API.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
}
