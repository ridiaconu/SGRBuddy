using Microsoft.AspNetCore.Mvc;
using SGRBuddy.BusinessLogic;
using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.Domain;

namespace SGRBuddy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SGRSessionController(SGRSessionService sgrSessionService) : ControllerBase
{
    /// <summary>
    /// Create a new SGR session
    /// </summary>
    [HttpPost]
    public IActionResult CreateSession([FromBody] SGRSessionDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Session data is required");
        }

        try
        {
            var sessionId = sgrSessionService.CreateSession(dto);
            return CreatedAtAction(nameof(GetSession), new { id = sessionId }, new { id = sessionId });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating session: {ex.Message}");
        }
    }

    /// <summary>
    /// Get a single SGR session by ID
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetSession(Guid Id)
    {
        try
        {
            var session = sgrSessionService.Get(Id);
            if (session == null)
            {
                return NotFound($"Session with Id {Id} not found");
            }
            return Ok(session);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving session: {ex.Message}");
        }
    }

     /// <summary>
    /// Get all SGR sessions
    /// </summary>
    [HttpGet]
    public IActionResult GetAllSessions()
    {
        try
        {
            var sessions = sgrSessionService.GetAll();
            return Ok(sessions);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving sessions: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public IActionResult EndSession([FromBody] Guid id)
    {
        try
        {
            sgrSessionService.EndSession(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error ending session: {ex.Message}");
        }
    }

    [HttpPost]
    public IActionResult AddToSession([FromBody] Guid sessionId, Guid itemId)
    {
        try
        {
            sgrSessionService.AddItemToSession(sessionId, itemId);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding item to session: {ex.Message}");
        }
    }
}