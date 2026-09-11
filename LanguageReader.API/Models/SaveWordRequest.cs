using System.ComponentModel.DataAnnotations;

namespace LanguageReader.API.Models;

/// <summary>
/// Request model for saving a word to vocabulary collection
/// </summary>
public class SaveWordRequest
{
    [Required(ErrorMessage = "WordId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "WordId must be a positive number")]
    public int WordId { get; set; }

    [Required(ErrorMessage = "BookId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "BookId must be a positive number")]
    public int BookId { get; set; }
}
