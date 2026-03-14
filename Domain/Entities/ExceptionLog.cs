namespace Domain.Entities;

public class ExceptionLog
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string ClassName { get; set; } = string.Empty;
    public string MethodName { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public string StackTrace { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}