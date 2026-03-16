using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logs.Api.Controller;


[ApiController]
[Route("api/[controller]")]
public class LogsController: ControllerBase
{
    private readonly ILogService _logService;

    public LogsController(ILogService logService)
    {
        _logService = logService;
    }
    
    [HttpGet("app")]
    public async Task<IActionResult> GetAllAppLogs()
    {
        var logs = await _logService.GetAllAppLogsAsync();
        return Ok(logs);
    }

    [HttpGet("access")]
    public async Task<IActionResult> GetAllAccessLogs()
    {
        var logs = await _logService.GetAllAccessLogsAsync();
        return Ok(logs);
    }
    
    [HttpGet("exception")]
    public async Task<IActionResult> GetAllExceptionLogs()
    {
        var logs = await _logService.GetAllExceptionLogsAsync();
        return Ok(logs);
    }

    [HttpGet("app/{module}")]
    public async Task<IActionResult> GetAppLogs(string module)
    {
        var logs = await _logService.GetAppLogsByModuleAsync(module);
        if (!logs.Any())
            return NotFound($"No se encontraron logs para el módulo: {module}");
            return Ok(logs);
    }

    
    



}   