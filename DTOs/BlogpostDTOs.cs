namespace PortfolioBackend.DTOs;

// Invoer voor POST
public class CreateBlogpostDto
{
    public string Titel { get; set; } = string.Empty;
    public string Inhoud { get; set; } = string.Empty;
    public DateTime Publicatiedatum { get; set; }
}

// Invoer voor PUT
public class UpdateBlogpostDto
{
    public string Titel { get; set; } = string.Empty;
    public string Inhoud { get; set; } = string.Empty;
    public DateTime Publicatiedatum { get; set; }
}

// Uitvoer voor GET
public class BlogpostResponseDto
{
    public int Id { get; set; }
    public string Titel { get; set; } = string.Empty;
    public string Inhoud { get; set; } = string.Empty;
    public DateTime Publicatiedatum { get; set; }
}