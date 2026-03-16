using Domain.Entities;
using Intercore.shared.DTOs;

namespace Application.Interfaces;

public interface ILogService
{
    Task ProcessAppLogAsync(CreateAppLogDto dto);
    Task ProcessAccessLogAsync(CreateAccessLogDto dto);
    Task ProcessExceptionLogAsync(CreateExceptionLogDto dto);
    Task<IEnumerable<AppLog>> GetAppLogsByModuleAsync(string module);
    Task<IEnumerable<AccessLog>> GetFailedLoginsAsync(int lastHours);

    Task<IEnumerable<AppLog>> GetAllAppLogsAsync();
    Task<IEnumerable<AccessLog>> GetAllAccessLogsAsync();
    Task<IEnumerable<ExceptionLog>> GetAllExceptionLogsAsync();

}