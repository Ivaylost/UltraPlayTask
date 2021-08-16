using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace UltraPlayTask.BackgroundJobs
{
    public class BackgroundDbUpdate : IHostedService
    {
        private readonly ILogger<BackgroundDbUpdate> logger;
        private readonly IWorker worker;

        public BackgroundDbUpdate(ILogger<BackgroundDbUpdate> logger, IWorker worker)
        {
            this.logger = logger;
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Database updated!");
            return Task.CompletedTask;
        }
    }
}
