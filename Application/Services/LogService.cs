using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

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
}