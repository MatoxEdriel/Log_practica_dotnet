using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities;

public class AccessLog
{
    [BsonId] 
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty; 
    public bool IsSuccess { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}