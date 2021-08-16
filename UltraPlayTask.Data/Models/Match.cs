using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraPlayTask.Data.Models
{
    public class Match : ISoftDelete
    {
        public Match()
        {
            Bets = new HashSet<Bet>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string PlayerOne { get; set; }
        public string PlayerTwo { get; set; }
        public DateTime StartDate { get; set; }
        public string MatchType { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletionDateTime { get; set; }

        public int EventId { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
    }
}
