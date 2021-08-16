using System.Collections.Generic;
using UltraPlayTask.Data.Models;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services.Updater.Contracts
{
    public interface IItemsForUpdate
    {
        List<Event> GetEvents(XmlSports input);

        List<Match> GetMatches(XmlSports input);

        List<Bet> GetBets(XmlSports input);

        List<Odd> GetOdds(XmlSports input);

        List<Event> GetEventsForDelet(XmlSports input);

        List<Match> GetMatchesForDelet(XmlSports input);

        List<Bet> GetBetsForDelet(XmlSports input);

        List<Odd> GetOddsForDelet(XmlSports input);

        List<Event> GetEventsForUpdate(XmlSports input);

        List<Match> GetMatchesForUpdate(XmlSports input);

        List<Odd> GetOddsForUpdate(XmlSports input);

        List<Bet> GetBetsForUpdate(XmlSports input);
    }
}
