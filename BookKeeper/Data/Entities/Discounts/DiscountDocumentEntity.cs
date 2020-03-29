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

    [Table("DiscountDocuments")]
    public class DiscountDocumentEntity : BaseEntity
    {
        public int AccountId { get; set; }

        [ForeignKey(nameof(AccountId))] 
        public AccountEntity Account { get; set; }

        public DiscountType Type { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Percent { get; set; }

        public string Description { get; set; }

        
    }
}
