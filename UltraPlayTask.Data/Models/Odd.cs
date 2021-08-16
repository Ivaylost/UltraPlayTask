using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UltraPlayTask.Data.Models
{
    public class Odd : ISoftDelete
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string SpecialBetValue { get; set; }

        public bool IsDeleted { get; set; }
        public DateTimeOffset? DeletionDateTime { get; set; }

        public int BetId { get; set; }
    }
}
