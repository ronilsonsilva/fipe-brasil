namespace FipeBrasil.WorkerService.Midleware
{
    public class ExceptionHandlingBackgroundService : BackgroundService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly ILogger<ExceptionHandlingBackgroundService> _logger;
        private readonly Func<CancellationToken, Task> _backgroundTask;

        public ExceptionHandlingBackgroundService(
            IHostApplicationLifetime applicationLifetime,
            ILogger<ExceptionHandlingBackgroundService> logger,
            Func<CancellationToken, Task> backgroundTask)
        {
            _applicationLifetime = applicationLifetime;
            _logger = logger;
            _backgroundTask = backgroundTask;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _backgroundTask(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred in the background service.");
                _applicationLifetime.StopApplication();
            }
        }
    }
}
