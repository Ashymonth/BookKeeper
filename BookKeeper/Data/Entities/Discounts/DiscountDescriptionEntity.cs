using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    public class DiscountDescriptionEntity : BaseEntity
    {
        public int DiscountDocumentId { get; set; }

        [ForeignKey(nameof(DiscountDocumentId))]
        public DiscountDocumentEntity DiscountDocument { get; set; }

        public string Description { get; set; }
    }
}
