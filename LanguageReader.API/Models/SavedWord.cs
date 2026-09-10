namespace LanguageReader.API.Models;

public class SavedWord
{
    public int Id { get; set; }
    public required int WordId { get; set; }
    // allow words to be added from other sources
    public int? BookId { get; set; }
    // Implement UserID when we have authentication
    // public int UserId { get; set; }
    public required DateTime DateSaved { get; set; }

    // Navigation properties
    public Word? Word { get; set; }
    public Book? Book { get; set; }
}