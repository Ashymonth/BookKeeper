using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    public enum DiscountType
    {
        Address,
        PersonalAccount
    }

    public class DiscountEntity : BaseEntity
    {
        public DiscountType Type { get; set; }

        public int? AddressEntityId { get; set; }

        public int? AccountEntityId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal DiscountPercent { get; set; }

        public string Description { get; set; }

    }
}
