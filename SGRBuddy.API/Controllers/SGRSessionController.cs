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
    public IActionResult CreateSession()
    {
        try
        {
            var sessionId = sgrSessionService.CreateSession();
            return Ok(sessionId);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating session: {ex.Message}");
        }
    }

    /// <summary>
    /// Get a single SGR session by ID
    /// </summary>
    [HttpGet("{Id}")]
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
    public IActionResult EndSession(Guid id)
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

    [HttpPost("remove-item")]
    public IActionResult AddToSession([FromBody] Guid sessionId, Guid itemId)
    {
        try
        {
            sgrSessionService.RemoveItemFromSession(sessionId, itemId);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding item to session: {ex.Message}");
        }
    }
}