namespace Domain.Entities;

public class AppLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string Module { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public Dictionary<string, object>? Payload { get; set; } 
        
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}