
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TaxComputationSoftware.Interfaces;

public class TimedHostedService : IHostedService, IDisposable
{
    private int executionCount = 0;
    private readonly IEmailService _emailService;
    private readonly ILogger<TimedHostedService> _logger;
    private Timer _timer;

    public TimedHostedService(IEmailService emailService, ILogger<TimedHostedService> logger)
    {
        _emailService = emailService;
        _logger = logger;
        
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, 
            TimeSpan.FromMinutes(30));

        return Task.CompletedTask;
    }

    private async void DoWork(object state)
    {
        var count = Interlocked.Increment(ref executionCount);

        _logger.LogError(
            "Timed Hosted Service is working. Count: {Count}", count);

        //await _emailService.Send("azibaalpha@gmail.com", "bomana.ogoni@gmail.com", "Timed Background Service", "Hi Bomzy Testing Timed Backbground Service", null, "Bomzy", "Bomana");
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}