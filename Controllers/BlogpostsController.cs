using Microsoft.AspNetCore.Mvc;
using PortfolioBackend.DTOs;
using PortfolioBackend.Services;

namespace PortfolioBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogpostsController : ControllerBase
{
    private readonly IBlogpostService _blogpostService;

    public BlogpostsController(IBlogpostService blogpostService)
    {
        _blogpostService = blogpostService;
    }

    // 1. GET: api/blogposts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BlogpostResponseDto>>> GetAll()
    {
        var blogposts = await _blogpostService.GetAllAsync();
        return Ok(blogposts);
    }

    // 2. GET: api/blogposts/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<BlogpostResponseDto>> GetById(int id)
    {
        var blogpost = await _blogpostService.GetByIdAsync(id);
        if (blogpost == null)
        {
            return NotFound();
        }

        return Ok(blogpost);
    }

    // 3. POST: api/blogposts
    [HttpPost]
    public async Task<ActionResult<BlogpostResponseDto>> Create(CreateBlogpostDto dto)
    {
        var createdBlogpost = await _blogpostService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = createdBlogpost.Id }, createdBlogpost);
    }

    // 4. PUT: api/blogposts/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateBlogpostDto dto)
    {
        var updated = await _blogpostService.UpdateAsync(id, dto);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // 5. DELETE: api/blogposts/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _blogpostService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}