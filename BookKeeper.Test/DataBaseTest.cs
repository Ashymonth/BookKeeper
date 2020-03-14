using System;
using System.Collections.Generic;
using System.Linq;
using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookKeeper.Test
{
    public class DataBaseTest
    {
        private ApplicationDbContext _dbContext;

        public DataBaseTest(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EntityEntry<AddressEntity> AddAddress(string name)
        {
            var address = _dbContext.Address.Add(new AddressEntity
            {
                CreatedDate = DateTime.Now
            });
            _dbContext.SaveChanges();
            return address;
        }

        public List<AddressEntity> GetAllAddress()
        {
            var query = from b in _dbContext.Address
                select b;

            return query.ToList();
        }
    }
}
