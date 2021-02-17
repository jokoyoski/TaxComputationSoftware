
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Taxcomputation.Interfaces;
using TaxComputationSoftware.Interfaces;

//Sample of time background service
public class TimedHostedService : IHostedService, IDisposable
{
    private int executionCount = 0;
    private readonly IServiceProvider _services;
    private readonly ILogger<TimedHostedService> _logger;
    private Timer _timer;

    public TimedHostedService(IServiceProvider services, ILogger<TimedHostedService> logger)
    {
        _services = services;
        _logger = logger;
        
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, stoppingToken, TimeSpan.Zero, 
            TimeSpan.FromMinutes(1));

        return Task.CompletedTask;
    }

    private async void DoWork(object state)
    {
        var count = Interlocked.Increment(ref executionCount);

        _logger.LogError(
            "Timed Hosted Service is working. Count: {Count}", count);
        
        
        await SendEmail((CancellationToken)state);

    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    private async Task SendEmail(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
                "Consume Scoped Service Hosted Service is working.");

        using (var scope = _services.CreateScope())
        {
            var scopedProcessingService = 
                scope.ServiceProvider
                    .GetRequiredService<IScopedProcessingService>();

            await scopedProcessingService.SendEmail(stoppingToken);
        }
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}