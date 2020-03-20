using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class Rate 
    {
        public string StreetName { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public decimal Price { get; set; }
    }
}
