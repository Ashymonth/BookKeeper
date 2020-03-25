using System.Security.AccessControl;
using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeper.Data.Models
{
    public class RateModel
    {
        public string Street { get; set; }

        public string House { get; set; }

        public string Building { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public RateDocumentEntity RateDocument { get; set; }
    }
}
