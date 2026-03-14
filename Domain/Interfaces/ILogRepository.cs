using Domain.Entities;

namespace Domain.Interfaces;

public interface ILogRepository
{
    Task InsertAppLogAsync(AppLog log);
    Task InsertAccessLogAsync(AccessLog log);
    Task InsertExceptionLogAsync(ExceptionLog log);

    Task<IEnumerable<AppLog>> GetAppLogsByModuleAsync(string module);
    Task<IEnumerable<AccessLog>> GetFailedLoginsAsync(int lastHours);
    
}