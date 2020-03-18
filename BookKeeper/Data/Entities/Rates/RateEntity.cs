using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Entities.Rates
{
    public class RateEntity : BaseEntity
    {
        public int StreetEntityId { get; set; }

        public StreetEntity Street { get; set; }

        public decimal DefaultPrice { get; set; } = 166;

        public decimal Price { get; set; }

        public bool IsDefault { get; set; }

        public DateTime RateCreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }


    }
}
