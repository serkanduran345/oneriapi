using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneriApi.Data;


[ApiController]
[Route("api/[controller]")]
public class ShoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ShoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("recommend")]
    public async Task<IActionResult> Recommend([FromQuery] decimal footLength)
    {
        var result = await _context.Shoes
            .Select(shoe => new
            {
                ShoeName = shoe.Name,

                BestSize = shoe.Sizes
                    .Where(s => s.InnerLength <= footLength)
                    .OrderByDescending(s => s.InnerLength)
                    .Select(s => s.Size)
                    .FirstOrDefault()
            })
            .ToListAsync();

        return Ok(result);
    }
}