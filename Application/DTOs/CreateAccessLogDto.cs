namespace Application.DTOs;

public class CreateAccessLogDto
{
    public string UserId { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty; 
    public bool IsSuccess { get; set; }
}