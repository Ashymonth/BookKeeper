using BookKeeper.Data.Data.Entities.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Discounts
{
    public enum DiscountType
    {
        Address,
        PersonalAccount
    }

    public class DiscountDocumentEntity : BaseEntity
    {
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public StreetEntity Street { get; set; }

        public DiscountType Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal DiscountPercent { get; set; }

        public ICollection<DiscountDescriptionEntity> DiscountDescriptions { get; set; }

    }
}
