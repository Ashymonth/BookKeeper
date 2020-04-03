using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Rates;

namespace BookKeeperTest.Rates
{
    public class RateComparer : IEqualityComparer<RateEntity>
    {
        public bool Equals(RateEntity x, RateEntity y)
        {
            if (x == null || y == null)
                return false;

            if (x.IsDeleted == false && y.IsDeleted == false &&
                x.StartDate.Date == y.StartDate.Date &&
                x.Description == y.Description &&
                x.Price == y.Price)
                return true;

            return false;
        }

        public int GetHashCode(RateEntity obj)
        {
            return obj.GetHashCode();
        }
    }
}
