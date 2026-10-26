using PortfolioBackend.DTOs;

namespace PortfolioBackend.Services;

public interface IBlogpostService
{
    Task<IEnumerable<BlogpostResponseDto>> GetAllAsync();
    Task<BlogpostResponseDto?> GetByIdAsync(int id);
    Task<BlogpostResponseDto> CreateAsync(CreateBlogpostDto dto);
    Task<bool> UpdateAsync(int id, UpdateBlogpostDto dto);
    Task<bool> DeleteAsync(int id);
}