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
    public IActionResult CreateItem([FromBody] SGRItemBaseDto dto)
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
    public IActionResult GetItem(Guid id)
    {
        try
        {
            var item = sgrItemService.GetSGRItems(id);
            if (item == null)
            {
                return NotFound($"Item with ID {id} not found");
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
    public IActionResult UpdateItem(Guid id, [FromBody] SGRItemDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Item data is required");
        }

        try
        {
            var updatedItem = sgrItemService.UpdateSGRItem(id, dto);
            return Ok(updatedItem);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating item: {ex.Message}");
        }
    }

    [HttpPut("{id}/update-count")]
    public IActionResult UpdateItemCount(Guid id)
    {
        if (id == null)
        {
            return BadRequest("Item ID is required");
        }

        try
        {
            var updatedCount = sgrItemService.UpdateCount(id);
            return Ok(new { id, count = updatedCount });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating item count: {ex.Message}");
        }
    }

    /// <summary>
    /// Delete an SGR item
    /// </summary>
    [HttpDelete("{id}")]
    public IActionResult DeleteItem(Guid id)
    {
        try
        {
            sgrItemService.DeleteSGRItem(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting item: {ex.Message}");
        }
    }
}