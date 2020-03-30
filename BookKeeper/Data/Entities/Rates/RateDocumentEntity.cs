using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Entities.Rates
{
    [Table("RateDocuments")]
    public class RateDocumentEntity : BaseEntity
    {
        public RateDocumentEntity()
        {
            RatesDescription = new List<RateDescriptionEntity>();
            StartDate = CreatedDate = DateTime.Now;
        }

        public int LocationId { get; set; }

        [ForeignKey(nameof(LocationId))]
        public virtual LocationEntity Location { get; set; }

        public decimal Price { get; set; }

        public bool IsDefaultPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<RateDescriptionEntity> RatesDescription { get; set; }

    }
}
