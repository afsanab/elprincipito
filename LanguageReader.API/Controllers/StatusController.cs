using Microsoft.AspNetCore.Mvc;

namespace LanguageReader.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatusController : ControllerBase
{
    // GET /api/status - Returns the status of the API
    [HttpGet]
    public ActionResult<StatusResponse> Get()
    {
        return Ok(new StatusResponse(
            Service: "LanguageReader API",
            Status: "running",
            Message: "The API is up. Open /swagger to explore endpoints."));
    }
}

public record StatusResponse(string Service, string Status, string Message);
