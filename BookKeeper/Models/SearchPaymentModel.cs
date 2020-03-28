using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class SearchPaymentModel
    {
        public int AccountId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

    }
}
