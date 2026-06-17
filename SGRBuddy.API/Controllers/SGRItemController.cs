using Microsoft.AspNetCore.Mvc;
using SGRBuddy.BusinessLogic;
using SGRBuddy.BusinessLogic.DTOs;
using SGRBuddy.Domain;

namespace SGRBuddy.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SGRItemController(SGRItemService sgrItemService) : ControllerBase
{
    /// <summary>
    /// Create a new SGR item
    /// </summary>
    [HttpPost]
    public IActionResult CreateItem([FromBody] SGRItemDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Item data is required");
        }

        try
        {
            var itemId = sgrItemService.CreateItem(dto);
            return CreatedAtAction(nameof(GetItem), new { id = itemId }, new { id = itemId });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error creating item: {ex.Message}");
        }
    }

    /// <summary>
    /// Get a single SGR item by ID
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult GetItem(Guid Id)
    {
        try
        {
            var item = sgrItemService.Get(Id);
            if (item == null)
            {
                return NotFound($"Item with Id {Id} not found");
            }
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving item: {ex.Message}");
        }
    }

    /// <summary>
    /// Get all SGR items
    /// </summary>
    [HttpGet]
    public IActionResult GetAllItems()
    {
        try
        {
            var items = sgrItemService.GetAll();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving items: {ex.Message}");
        }
    }

    /// <summary>
    /// Update an existing SGR item
    /// </summary>
    [HttpPut("{id}")]
    public IActionResult UpdateItem(Guid Id, [FromBody] SGRItemDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Item data is required");
        }

        try
        {
            var updatedItem = sgrItemService.UpdateSGRItem(Id, dto);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating item: {ex.Message}");
        }
    }
    

    /// <summary>
    /// Delete an SGR item
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteItem(Guid Id)
    {
        try
        {
            sgrItemService.DeleteSGRItem(Id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting item: {ex.Message}");
        }
    }
}