using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Entities.Rates
{
    public class RateDocumentEntity : BaseEntity
    {
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public StreetEntity Street { get; set; }

        public decimal DefaultPrice { get; set; }

        public decimal Price { get; set; }

        public bool IsDefault { get; set; }

        public DateTime RateRegisterDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<RateDescriptionEntity> RatesDescription{ get; set; }

    }
}
