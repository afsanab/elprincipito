using Microsoft.AspNetCore.Mvc;
using LanguageReader.API.Services;
using LanguageReader.API.Models;

namespace LanguageReader.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SavedWordsController : ControllerBase
{
    private readonly ISavedWordService _savedWordService;

    public SavedWordsController(ISavedWordService savedWordService)
    {
        _savedWordService = savedWordService;
    }

    // POST /api/savedwords - Save a word to your vocabulary collection
    [HttpPost]
    public async Task<ActionResult> SaveWord([FromBody] SaveWordRequest request)
    {
        // Validate model (checks Required attributes)
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Validate that the word exists
        if (!await _savedWordService.WordExistsAsync(request.WordId))
        {
            return NotFound(new { message = $"Word with ID {request.WordId} not found" });
        }

        // Validate that the book exists
        if (!await _savedWordService.BookExistsAsync(request.BookId))
        {
            return NotFound(new { message = $"Book with ID {request.BookId} not found" });
        }

        // Check for duplicate - prevent saving the same word from the same book twice
        if (await _savedWordService.IsDuplicateAsync(request.WordId, request.BookId))
        {
            return Conflict(new 
            { 
                message = "This word from this book is already in your saved collection"
            });
        }

        // Create the saved word entry using the service
        var savedWord = await _savedWordService.SaveWordAsync(request.WordId, request.BookId);

        return CreatedAtAction(nameof(GetSavedWords), new { id = savedWord.Id }, savedWord);
    }

    // GET /api/savedwords - Retrieve all saved vocabulary
    [HttpGet]
    public async Task<ActionResult> GetSavedWords()
    {
        var savedWords = await _savedWordService.GetAllSavedWordsAsync();
        return Ok(savedWords);
    }

    // DELETE /api/savedwords/{id} - Remove a word from your saved collection
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSavedWord(int id)
    {
        var deleted = await _savedWordService.DeleteSavedWordAsync(id);

        if (!deleted)
        {
            return NotFound(new { message = $"Saved word with ID {id} not found" });
        }

        return NoContent(); // 204 No Content - standard for successful DELETE
    }
}
