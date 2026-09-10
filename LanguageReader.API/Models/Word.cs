namespace LanguageReader.API.Models;

public class Word
{
    public int Id { get; set; }
    public required string WordText { get; set; }
    public required string Definition { get; set; }
    public required string Language { get; set; }

}