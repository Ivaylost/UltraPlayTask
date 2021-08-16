using Microsoft.Extensions.DependencyInjection;
using UltraPlayTask.Data;
using UltraPlayTask.Services.Updater.Contracts;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater
{
    public class DeleteItems : IDeleteItems
    {
        private readonly IItemsForUpdate items;
        private readonly AppDbContext context;

        public DeleteItems(IItemsForUpdate items, IServiceScopeFactory factory)
        {
            this.items = items;
            this.context = factory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        }

        public void Delete(XmlSports xml)
        {
            context.RemoveRange(items.GetEventsForDelet(xml));
            context.RemoveRange(items.GetMatchesForDelet(xml));
            context.RemoveRange(items.GetBetsForDelet(xml));
            context.RemoveRange(items.GetOddsForDelet(xml));

            context.SaveChanges();
        }
    }
}
