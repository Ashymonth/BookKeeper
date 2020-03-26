using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeper.UI.Models.Rate
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
