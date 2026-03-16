using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Intercore.shared.DTOs;

namespace Application.Services;

public class LogService: ILogService
{
    
    private readonly ILogRepository _logRepository;
    
    public LogService(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }
    
    public async Task ProcessAppLogAsync(CreateAppLogDto dto)
    {
        var appLog = new AppLog
        {
            UserId = dto.UserId,
            Module = dto.Module,
            Action = dto.Action,
            Payload = dto.Payload
        };
        await _logRepository.InsertAppLogAsync(appLog);
    }
    
    public async Task ProcessAccessLogAsync(CreateAccessLogDto dto)
    {
        var accessLog = new AccessLog
        {
            UserId = dto.UserId,
            IpAddress = dto.IpAddress,
            Action = dto.Action,
            IsSuccess = dto.IsSuccess
        };

        await _logRepository.InsertAccessLogAsync(accessLog);
    }

    public async Task ProcessExceptionLogAsync(CreateExceptionLogDto dto)
    {
        var exceptionLog = new ExceptionLog
        {
            ClassName = dto.ClassName,
            MethodName = dto.MethodName,
            ErrorMessage = dto.ErrorMessage,
            StackTrace = dto.StackTrace
        };

        await _logRepository.InsertExceptionLogAsync(exceptionLog);
    }

    public async Task<IEnumerable<AppLog>> GetAppLogsByModuleAsync(string module)
    {
        return await _logRepository.GetAppLogsByModuleAsync(module);
    }

    public async Task<IEnumerable<AccessLog>> GetFailedLoginsAsync(int lastHours)
    {
        return await _logRepository.GetFailedLoginsAsync(lastHours);
        
    }

    public async Task<IEnumerable<AppLog>> GetAllAppLogsAsync()
    {
        return await _logRepository.GetAllAppLogsAsync();
        
    }

    public async Task<IEnumerable<AccessLog>> GetAllAccessLogsAsync()
    {
        return await _logRepository.GetAllAccessLogsAsync();
    }

    public async Task<IEnumerable<ExceptionLog>> GetAllExceptionLogsAsync()
    {
        return await _logRepository.GetAllExceptionLogsAsync();
        
    }
}