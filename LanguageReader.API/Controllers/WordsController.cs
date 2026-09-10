using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanguageReader.API.Data;
using LanguageReader.API.Models;

namespace LanguageReader.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WordsController(AppDbContext context)
    {
        _context = context;
    }

    // GET /api/words/{word} - Returns a specific word by its text
    [HttpGet("{word}")]
    public async Task<ActionResult> GetWord(string word)
    {
        var wordEntry = await _context.Words
            .FirstOrDefaultAsync(w => w.WordText.ToLower() == word.ToLower());

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
