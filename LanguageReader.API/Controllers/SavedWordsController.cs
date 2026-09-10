using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanguageReader.API.Data;
using LanguageReader.API.Models;
using System.ComponentModel.DataAnnotations;

namespace LanguageReader.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SavedWordsController : ControllerBase
{
    private readonly AppDbContext _context;

    public SavedWordsController(AppDbContext context)
    {
        _context = context;
    }

    // POST /api/savedwords - Save a word to your vocabulary collection
    [HttpPost]
    public async Task<ActionResult<SavedWord>> SaveWord([FromBody] SaveWordRequest request)
    {
        // Validate model (checks Required attributes)
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Validate that the word exists
        var word = await _context.Words.FindAsync(request.WordId);
        if (word == null)
        {
            return NotFound(new { message = $"Word with ID {request.WordId} not found" });
        }

        // Validate that the book exists
        var book = await _context.Books.FindAsync(request.BookId);
        if (book == null)
        {
            return NotFound(new { message = $"Book with ID {request.BookId} not found" });
        }

        // Check for duplicate - prevent saving the same word from the same book twice
        var existingSavedWord = await _context.SavedWords
            .FirstOrDefaultAsync(sw => sw.WordId == request.WordId && sw.BookId == request.BookId);
        
        if (existingSavedWord != null)
        {
            return Conflict(new 
            { 
                message = "This word from this book is already in your saved collection",
                existingSavedWordId = existingSavedWord.Id
            });
        }

        // Create the saved word entry
        var savedWord = new SavedWord
        {
            WordId = request.WordId,
            BookId = request.BookId,
            DateSaved = DateTime.UtcNow
        };

        _context.SavedWords.Add(savedWord);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSavedWords), new { id = savedWord.Id }, savedWord);
    }

    // GET /api/savedwords - Retrieve all saved vocabulary
    [HttpGet]
    public async Task<ActionResult> GetSavedWords()
    {
        var savedWords = await _context.SavedWords
            .Include(sw => sw.Word)    // Load the Word navigation property
            .Include(sw => sw.Book)    // Load the Book navigation property
            .OrderByDescending(sw => sw.DateSaved)  // Most recent first
            .ToListAsync();

        // Return in the format: word text, definition, book title
        var result = savedWords.Select(sw => new
        {
            id = sw.Id,
            word = sw.Word!.WordText,
            definition = sw.Word!.Definition,
            book = sw.Book!.Title,
            dateSaved = sw.DateSaved
        });

        return Ok(result);
    }

    // DELETE /api/savedwords/{id} - Remove a word from your saved collection
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSavedWord(int id)
    {
        var savedWord = await _context.SavedWords.FindAsync(id);

        if (savedWord == null)
        {
            return NotFound(new { message = $"Saved word with ID {id} not found" });
        }

        _context.SavedWords.Remove(savedWord);
        await _context.SaveChangesAsync();

        return NoContent(); // 204 No Content - standard for successful DELETE
    }
}

// Request model for saving a word
public class SaveWordRequest
{
    [Required(ErrorMessage = "WordId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "WordId must be a positive number")]
    public int WordId { get; set; }

    [Required(ErrorMessage = "BookId is required")]
    [Range(1, int.MaxValue, ErrorMessage = "BookId must be a positive number")]
    public int BookId { get; set; }
}
