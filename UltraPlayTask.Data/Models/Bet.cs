using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraPlayTask.Data.Models
{
    public class Bet : ISoftDelete
    {
        public Bet()
        {
            Odds = new HashSet<Odd>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsLive { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletionDateTime { get; set; }

        public int MatchId { get; set; }
        public virtual ICollection<Odd> Odds { get; set; }
    }
}
