using System;
using BookKeeper.Data.Data.Entities;

namespace BookKeeper.Data.Models
{
    public class SearchModel
    {
        public int StreetId { get; set; }

        public string Account { get; set; }

        public AccountType AccountType { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public bool IsArchive { get; set; }

        public bool IsNoneBuilding { get; set; }

        public bool IsNotPayed { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

    }
}
