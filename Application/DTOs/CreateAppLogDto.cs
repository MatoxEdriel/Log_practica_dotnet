namespace Application.DTOs;

public class CreateAppLogDto
{
    public string UserId { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty; 
    public string Action { get; set; } = string.Empty; 
    public Dictionary<string, object>? Payload { get; set; }
}