using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using UltraPlayTask.Services;
using UltraPlayTask.Services.Updater.Contracts;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.BackgroundJobs
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private readonly IReadInput reader;
        private readonly ISaveItems item;
        private readonly IDeleteItems itemsForDelete;
        private XmlSports xml;

        public Worker(ILogger<Worker> logger, 
                        IServiceScopeFactory factory,
                        IReadInput reader,
                        ISaveItems item,
                        IDeleteItems itemsForDelete)
        {
            this.logger = logger;
            this.reader = reader;
            this.item = item;
            this.itemsForDelete = itemsForDelete;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            

            while (!cancellationToken.IsCancellationRequested)
            {
                this.xml = reader.Read();
                this.item.Save(this.xml);
                this.itemsForDelete.Delete(this.xml);
                logger.LogInformation("Updated!");
                await Task.Delay(Constants.UpdatePeriod);
            }
        }
    }
}
