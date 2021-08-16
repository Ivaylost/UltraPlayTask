using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using UltraPlayTask.Data;
using UltraPlayTask.Data.Models;
using UltraPlayTask.Services.Updater.Contracts;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater
{
    public class ItemsForUpdate : IItemsForUpdate
    {
        private readonly AppDbContext context;

        public ItemsForUpdate(IServiceScopeFactory factory)
        {
            this.context = factory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
        }

        private List<int> GetXmlEventsIds(XmlSports input) => input.XmlSport.XmlEvents
            .Select(x => x.ID).ToList();

        private List<int> GetXmlMatchesIds(XmlSports input) => input.XmlSport.XmlEvents
            .SelectMany(x => x.XmlMatches.Select(y => y.ID)).ToList();

        private List<int> GetXmlBetsIds(XmlSports input) => input.XmlSport.XmlEvents
            .SelectMany(x => x.XmlMatches.SelectMany(y => y.XmlBets.Select(b => b.ID))).ToList();

        private List<int> GetXmlOddsIds(XmlSports input) => input.XmlSport.XmlEvents
            .SelectMany(x => x.XmlMatches.SelectMany(y => y.XmlBets.SelectMany(o => o.XmlOdds.Select(c => c.ID)))).ToList();

        private List<int> GetDbEventsIds() => this.context.Events.Where(x=>x.IsDeleted == false).Select(e => e.ID).ToList();


        private List<int> GetDbMatchesIds() => this.context.Matches.Where(x => x.IsDeleted == false).Select(e => e.ID).ToList();

        private List<int> GetDbBetsIds() => this.context.Bets.Where(x => x.IsDeleted == false).Select(e => e.ID).ToList();

        private List<int> GetDbOddsIds() => this.context.Odds.Where(x => x.IsDeleted == false).Select(e => e.ID).ToList();

        public List<Event> GetEventsForUpdate(XmlSports input)
        {
            var deletedIds = this.context.Events.Where(x => x.IsDeleted == true).Select(y => y.ID).ToList();
            var xmlEventsIds = GetXmlEventsIds(input);
            var ids = deletedIds.Where(x => xmlEventsIds.Contains(x));

            var events = this.context.Events.Where(x => ids.Contains(x.ID)).ToList();
            foreach (var item in events)
            {
                item.IsDeleted = false;
            }
            return events;
        }

        public List<Match> GetMatchesForUpdate(XmlSports input)
        {
            var deletedIds = this.context.Matches.Where(x => x.IsDeleted == true).Select(y => y.ID).ToList();
            var xmlMatchesIds = GetXmlMatchesIds(input);
            var ids = deletedIds.Where(x => xmlMatchesIds.Contains(x));

            var matches = this.context.Matches.Where(x => ids.Contains(x.ID)).ToList();
            foreach (var item in matches)
            {
                item.IsDeleted = false;
            }
            return matches;
        }

        public List<Odd> GetOddsForUpdate(XmlSports input)
        {
            var deletedIds = this.context.Odds.Where(x => x.IsDeleted == true).Select(y => y.ID).ToList();
            var xmlOddsIds = GetXmlOddsIds(input);
            var ids = deletedIds.Where(x => xmlOddsIds.Contains(x));

            var odds = this.context.Odds.Where(x => ids.Contains(x.ID)).ToList();
            foreach (var item in odds)
            {
                item.IsDeleted = false;
            }
            return odds;
        }

        public List<Bet> GetBetsForUpdate(XmlSports input)
        {
            var deletedIds = this.context.Bets.Where(x => x.IsDeleted == true).Select(y => y.ID).ToList();
            var xmlBetsIds = GetXmlBetsIds(input);
            var ids = deletedIds.Where(x => xmlBetsIds.Contains(x));

            var bets = this.context.Bets.Where(x => ids.Contains(x.ID)).ToList();
            foreach (var item in bets)
            {
                item.IsDeleted = false;
            }
            return bets;
        }

        public List<Event> GetEvents(XmlSports input) => Parser.Events(GetXmlEventsIds(input).Except(GetDbEventsIds()).ToList(), input);

        public List<Match> GetMatches(XmlSports input) => Parser.Matches(GetXmlMatchesIds(input).Except(GetDbMatchesIds()).ToList(), input);

        public List<Bet> GetBets(XmlSports input) => Parser.Bets(GetXmlBetsIds(input).Except(GetDbBetsIds()).ToList(), input);

        public List<Odd> GetOdds(XmlSports input) => Parser.Odds(GetXmlOddsIds(input).Except(GetDbOddsIds()).ToList(), input);

        public List<Event> GetEventsForDelet(XmlSports input) => this.context.Events.Where(x=>x.IsDeleted == false)
            .Select(e => e.ID).ToList().Except(GetXmlEventsIds(input))
            .Select(x => context.Events.Where(z => z.ID == x).FirstOrDefault()).ToList();

        public List<Match> GetMatchesForDelet(XmlSports input) => this.context.Matches.Where(x => x.IsDeleted == false)
            .Select(e => e.ID).ToList().Except(GetXmlMatchesIds(input))
            .Select(z => context.Matches.Where(c => c.ID == z).FirstOrDefault()).ToList();

        public List<Bet> GetBetsForDelet(XmlSports input) => this.context.Bets.Where(x => x.IsDeleted == false)
            .Select(e => e.ID).ToList().Except(GetXmlBetsIds(input))
            .Select(x => context.Bets.Where(y => y.ID == x).FirstOrDefault()).ToList();

        public List<Odd> GetOddsForDelet(XmlSports input) => this.context.Odds.Where(x => x.IsDeleted == false)
            .Select(e => e.ID).ToList().Except(GetXmlOddsIds(input))
            .Select(x => context.Odds.Where(y => y.ID == x).FirstOrDefault()).ToList();
    }
}
