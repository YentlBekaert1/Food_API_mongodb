using Mongodexample.Models;
using Mongodexample.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly FoodService _foodService;

    public FoodController(FoodService foodService) =>
        _foodService = foodService;

    [HttpGet]
    public async Task<List<Food>> Get() =>
        await _foodService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Food>> Get(string id)
    {
        var food = await _foodService.GetAsync(id);

        if (food is null)
        {
            return NotFound();
        }

        return food;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Food newFood)
    {
        await _foodService.CreateAsync(newFood);

        return CreatedAtAction(nameof(Get), new { id = newFood.Id }, newFood);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Food updatedFood)
    {
        var food = await _foodService.GetAsync(id);

        if (food is null)
        {
            return NotFound();
        }

        updatedFood.Id = food.Id;

        await _foodService.UpdateAsync(id, updatedFood);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var food = await _foodService.GetAsync(id);

        if (food is null)
        {
            return NotFound();
        }

        await _foodService.RemoveAsync(food.Id);

        return NoContent();
    }
}