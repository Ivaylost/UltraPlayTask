using System.Threading;
using System.Threading.Tasks;

namespace UltraPlayTask.BackgroundJobs
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}