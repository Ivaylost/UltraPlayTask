using System.Collections.Generic;
using System.Linq;
using UltraPlayTask.Data.Models;
using UltraPlayTask.Services.XmlModels;

namespace UltraPlayTask.Services
{
    public static class Parser 
    {
        public static List<Event> Events(List<int> eventsToAdd, XmlSports input) => input.XmlSport.XmlEvents.Where(x => eventsToAdd.Contains(x.ID))
                            .Select(y => new Event()
                            {
                                CategoryID = y.CategoryID,
                                ID = y.ID,
                                IsLive = y.IsLive,
                                Name = y.Name,
                            }).ToList();

        public static List<Match> Matches(List<int> matchsToAdd, XmlSports input) => input.XmlSport.XmlEvents.SelectMany(x => x.XmlMatches.Where(o => matchsToAdd.Contains(o.ID))
                            .Select(y => new Match()
                            {
                                PlayerOne = y.Name.Split('-').FirstOrDefault().Trim(),
                                PlayerTwo = y.Name.Split('-').LastOrDefault().Trim(),
                                MatchType = y.MatchType,
                                StartDate = y.StartDate,
                                ID = y.ID,
                                EventId=x.ID,
                            })).ToList();

        public static List<Bet> Bets(List<int> betsToAdd, XmlSports input) => input.XmlSport.XmlEvents.SelectMany(x => x.XmlMatches
                        .SelectMany(m => m.XmlBets.Where(b => betsToAdd.Contains(b.ID))
                        .Select(y => new Bet()
                        {
                            ID = y.ID,
                            IsLive = y.IsLive,
                            Name = y.Name,
                            MatchId = m.ID,
                        }))).ToList();

        public static List<Odd> Odds(List<int> oddsToAdd, XmlSports input) => input.XmlSport.XmlEvents.SelectMany(x => x.XmlMatches
                        .SelectMany(m => m.XmlBets.SelectMany(z => z.XmlOdds.Where(b => oddsToAdd.Contains(b.ID))
                        .Select(y => new Odd()
                        {
                            ID = y.ID,
                            Name = y.Name,
                            SpecialBetValue = y.SpecialBetValue,
                            Value = y.Value,
                            BetId=z.ID,
                        })))).ToList();
    }
}
