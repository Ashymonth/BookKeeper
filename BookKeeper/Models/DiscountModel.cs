using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Discounts;

namespace BookKeeper.Data.Models
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
