using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Data.Entities.Rates
{
    public class RateDescriptionEntity : BaseEntity
    {
        public int RateDocumentId { get; set; }

        [ForeignKey(nameof(RateDocumentId))]
        public RateDocumentEntity RateDocument { get; set; }

        public string Description { get; set; }
    }
}
