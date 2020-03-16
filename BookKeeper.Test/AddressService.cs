using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Test
{
    public class AddressService
    {
        private readonly ApplicationDbContext _dbContext;

        public AddressService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EntityEntry<StreetEntity> AddAddress(string addressName)
        {
            var result = _dbContext.Streets.Add(new StreetEntity { StreetName = addressName });
            _dbContext.SaveChanges();
            return result;
        }

        public List<StreetEntity> GetAddresses()
        {
            var query = from a in _dbContext.Streets select a;
            return query.ToList();
        }
    }
}
