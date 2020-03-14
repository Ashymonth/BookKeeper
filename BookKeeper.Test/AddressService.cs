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

        public EntityEntry<AddressEntity> AddAddress(string addressName)
        {
            var result = _dbContext.Addresses.Add(new AddressEntity { StreetName = addressName });
            _dbContext.SaveChanges();
            return result;
        }

        public List<AddressEntity> GetAdresses()
        {
            var query = from a in _dbContext.Addresses select a;
            return query.ToList();
        }
    }
}
