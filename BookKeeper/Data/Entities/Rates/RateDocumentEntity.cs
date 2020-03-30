using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Entities.Rates
{
    [Table("Rates")]
    public class RateEntity : BaseEntity
    {
        public decimal Price { get; set; }
        
        public bool IsDefault { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RateDetailsEntity> AssignedLocations { get; set; }
    }
}
