using Application.DTOs;

namespace Application.Interfaces;

public interface ILogService
{
    Task ProcessAppLogAsync(CreateAppLogDto dto);
    Task ProcessAccessLogAsync(CreateAccessLogDto dto);
    Task ProcessExceptionLogAsync(CreateExceptionLogDto dto);
}