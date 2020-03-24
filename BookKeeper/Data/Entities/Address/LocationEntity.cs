﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace BookKeeper.Data.Data.Entities.Address
{
    public class LocationEntity : BaseEntity
    {
        public int StreetId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public virtual StreetEntity Street { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingCorpus { get; set; }

        public string ApartmentNumber { get; set; }

    }
}
