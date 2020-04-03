using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Discounts;

namespace BookKeeperTest.Discounts
{
    public class DiscountComparer : IEqualityComparer<DiscountDocumentEntity>
    {
        public bool Equals(DiscountDocumentEntity x, DiscountDocumentEntity y)
        {
            if (x == null || y == null)
                return false;

            if (x.AccountId == y.AccountId &&
                !x.IsDeleted && !y.IsDeleted &&
                x.StartDate.Date == y.StartDate.Date &&
                x.EndDate.Date == y.EndDate.Date &&
                x.Type == y.Type &&
                x.Percent == y.Percent &&
                x.Description == y.Description)
                return true;
            else
                return false;
        }

        public int GetHashCode(DiscountDocumentEntity obj)
        {
            return obj.GetHashCode();
        }
    }

    public class CurrentDiscountComparer : IEqualityComparer<DiscountDocumentEntity>
    {
        public bool Equals(DiscountDocumentEntity x, DiscountDocumentEntity y)
        {
            if (x == null || y == null)
                return false;

            if (x.AccountId == y.AccountId &&
                !x.IsDeleted && !y.IsDeleted &&
                x.StartDate.Date == y.StartDate.Date &&
                x.EndDate.Date == y.EndDate.Date &&
                x.Percent == y.Percent &&
                x.Description == y.Description)
                return true;
            else
                return false;
        }

        public int GetHashCode(DiscountDocumentEntity obj)
        {
            return obj.GetHashCode();
        }
    }
}
