using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Address;

namespace BookKeeper.Data.Data.Entities.Rates
{
    [Table("RateDetails")]
    public class RateDetailsEntity : BaseEntity
    {
        public int LocationRefId { get; set; }

        [ForeignKey(nameof(LocationRefId))]
        public virtual LocationEntity Location { get; set; }
    }
}
