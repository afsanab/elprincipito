using Microsoft.AspNetCore.Mvc;
using LanguageReader.API.Services;

namespace LanguageReader.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    private readonly IWordService _wordService;

    public WordsController(IWordService wordService)
    {
        _wordService = wordService;
    }

    // GET /api/words/{word} - Returns a specific word by its text
    [HttpGet("{word}")]
    public async Task<ActionResult> GetWord(string word)
    {
        var wordEntry = await _wordService.GetWordByTextAsync(word);

        if (wordEntry == null)
        {
            return NotFound(new { message = $"Word '{word}' not found" });
        }

        return Ok(new
        {
            word = wordEntry.WordText,
            definition = wordEntry.Definition,
            language = wordEntry.Language
        });
    }
}
