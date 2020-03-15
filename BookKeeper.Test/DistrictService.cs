using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace BookKeeper.Test
{
    public class DistrictService
    {
        private readonly ApplicationDbContext _dbContext;

        public DistrictService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EntityEntry<DistrictEntity> AddDistrictEntity(string districtName, DistrictType districtType)
        {
            var result = _dbContext.Districts.Add(new DistrictEntity
            {
                Name = districtName,
            });
            _dbContext.SaveChanges();
            return result;
        }

        public IEnumerable<DistrictEntity> GetAllDistricts()
        {
            var result = from d in _dbContext.Districts select d;

            return result.ToList();
        }
    }
}
