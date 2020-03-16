﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Address
{
    public class StreetEntity : BaseEntity
    {
        
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual DistrictEntity District { get; set; }

        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public virtual List<LocationEntity> Location { get; set; }

        public string StreetName { get; set; }

    }
}