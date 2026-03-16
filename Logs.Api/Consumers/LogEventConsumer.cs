using Application.Interfaces;
using Intercore.shared.DTOs;
using MassTransit;

namespace Logs.Api.Consumers;

public class LogEventConsumer:IConsumer<CreateAppLogDto>,IConsumer<CreateAccessLogDto>,IConsumer<CreateExceptionLogDto> 
{
    private readonly ILogService _logService;
    
    public LogEventConsumer(ILogService logService)
    {
        _logService = logService;
    }
    
    
    public async Task Consume(ConsumeContext<CreateAppLogDto> context)
    {
        await _logService.ProcessAppLogAsync(context.Message);
        
    }

    public async Task Consume(ConsumeContext<CreateAccessLogDto> context)
    {
        await _logService.ProcessAccessLogAsync(context.Message);
    }

    public async Task Consume(ConsumeContext<CreateExceptionLogDto> context)
    {
        await _logService.ProcessExceptionLogAsync(context.Message);
        
    }
}