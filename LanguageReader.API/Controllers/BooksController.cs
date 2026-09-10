using Microsoft.AspNetCore.Mvc;
using LanguageReader.API.Services;

namespace LanguageReader.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    // GET /api/books - Returns all books
    [HttpGet]
    public async Task<ActionResult> GetBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    // GET /api/books/{id} - Returns a specific book by ID
    [HttpGet("{id}")]
    public async Task<ActionResult> GetBook(int id)
    {
        var book = await _bookService.GetBookByIdAsync(id);

        if (book == null)
        {
            return NotFound(new { message = $"Book with ID {id} not found" });
        }

        return Ok(book);
    }
}
