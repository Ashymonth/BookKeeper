using BookKeeper.Data.Data;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using DocumentFormat.OpenXml.Wordprocessing;
using LinqKit;
using Microsoft.EntityFrameworkCore.Internal;

namespace BookKeeper.Test
{
    [TestClass]
    public class FilterTest
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        private SearchModel model = new SearchModel
        {
            HouseNumber = "105",
            ApartmentNumber = "180"

        };
        [TestMethod]
        public void FindLocationTest()
        {

            var predicate = PredicateBuilder.New<LocationEntity>();

            Expression<Func<LocationEntity, bool>> housePredicate = entity =>
                entity.HouseNumber.Equals(model.HouseNumber, StringComparison.OrdinalIgnoreCase);

            Expression<Func<LocationEntity, bool>> buildingPredicate = entity =>
                entity.BuildingCorpus.Equals(model.BuildingNumber, StringComparison.OrdinalIgnoreCase);

            Expression<Func<LocationEntity, bool>> apartmentPredicate = entity =>
                entity.ApartmentNumber.Equals(model.ApartmentNumber, StringComparison.OrdinalIgnoreCase);

            if (string.IsNullOrWhiteSpace(model.HouseNumber) == false)
            {
                predicate = predicate.And(housePredicate);
            }

            if (string.IsNullOrWhiteSpace(model.BuildingNumber) == false)
            {
                predicate.And(buildingPredicate);
            }

            if (string.IsNullOrWhiteSpace(model.ApartmentNumber) == false)
            {
                predicate = predicate.And(apartmentPredicate);
            }

            var x = _dbContext.Locations.Where(predicate).ToList();


        }
    }
}
