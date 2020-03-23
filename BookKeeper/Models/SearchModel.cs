using BookKeeper.Data.Data.Entities;

namespace BookKeeper.Data.Models
{
    public class SearchModel
    {
        public int StreetId { get; set; }

        public AccountType AccountType { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public bool IsArchive { get; set; }

    }
}
