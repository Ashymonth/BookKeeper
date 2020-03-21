using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.UI.Models
{
    public class SearchModel
    {
        public int AddressId { get; set; }

        public int AccountType { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public bool IsArchive { get; set; }

    }
}
