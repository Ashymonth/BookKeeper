﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKeeper.Data.Models
{
    public class AccountDetailsModel
    {
        public string Account { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Building { get; set; }

        public string Apartment { get; set; }

        public string Received { get; set; }

        public string Accrued { get; set; }

        public string Rate { get; set; }

        public string Discount { get; set; }
    }
}
