

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Taxcomputation.Interfaces;
using TaxComputationAPI.Helpers;
using TaxComputationSoftware.Interfaces;

namespace TaxComputationSoftware.Services
{
    public class ScopedProcessingService : IScopedProcessingService
    {
        private int executionCount = 0;
        private readonly IEmailService _emailService;
        private readonly ILogger _logger;
    
        public ScopedProcessingService(IEmailService emailService, ILogger<ScopedProcessingService> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        public async Task SendEmail(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                executionCount++;

                _logger.LogInformation("Scoped Processing Service is working. Count: {Count}", executionCount);

                //await _emailService.PreNotificationEmail("Alexo", DateTime.UtcNow);

                //string money = "3443253".ValueMoneyFormatter("NGN", true);

                await Task.Delay(10000, stoppingToken);
            }
        }   
    }
}


