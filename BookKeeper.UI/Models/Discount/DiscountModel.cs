using BookKeeper.Data.Data.Entities.Discounts;

namespace BookKeeper.UI.Models.Discount
{
    public class DiscountModel
    {
        public DiscountType Type { get; set; }

        public string Address { get; set; }

        public string Account { get; set; }

        public string Price { get; set; }

        public string Description { get; set; }

        public int DiscountId { get; set; }

    }
}
