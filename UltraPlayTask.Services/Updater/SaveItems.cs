using Microsoft.Extensions.DependencyInjection;
using UltraPlayTask.Data;
using UltraPlayTask.Services.Updater.Contracts;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater
{
    public class SaveItems : ISaveItems
    {
        private readonly IItemsForUpdate items;
        private readonly AppDbContext context;

        public SaveItems(IItemsForUpdate items, IServiceScopeFactory factory)
        {
            this.items = items;
            this.context = factory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        }

        public void Save(XmlSports xml)
        {
            context.UpdateRange(items.GetEventsForUpdate(xml));
            context.UpdateRange(items.GetMatchesForUpdate(xml));
            context.UpdateRange(items.GetBetsForUpdate(xml));
            context.UpdateRange(items.GetOddsForUpdate(xml));
            context.SaveChanges();

            context.AddRange(items.GetEvents(xml));
            context.AddRange(items.GetMatches(xml));
            context.AddRange(items.GetBets(xml));
            context.AddRange(items.GetOdds(xml));
            context.SaveChanges();
        }
    }
}
