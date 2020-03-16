using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BookKeeper.Data.Data.Entities.Address;
using BookKeeper.Data.Models.ExcelImport;
using BookKeeper.Data.Services.Import;

namespace BookKeeper.Data.Services.Load
{
    public class ExcelDataLoader : IDataLoader
    {
        private readonly IDictionary<string, int> _districtCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private readonly IImport _import;
        private readonly IDistrictService _districtService;

        public ExcelDataLoader(IImport import, IDistrictService districtService)
        {
            _import = import;
            _districtService = districtService;
        }

        public void LoadData(string file)
        {
            var import = _import.ImportDataRow("");
            var query = import
                .GroupBy(x => new
                {
                    Districts = x.District.Name,
                })
                .Select(x => new
                {
                    x.Key.Districts,
                    Addresses = x.GroupBy(a => new
                    {
                        Addresses = a.Address.Name
                    })
                        .Select(a => new
                        {
                            a.Key.Addresses,
                            Location = a.GroupBy(l => new
                            {
                                Location = l.LocationImport
                            })
                                .Select(l => l.Key.Location)
                                .ToList()
                        })
                }).ToList();

            var testData = new List<TestData>();
            testData.Add(new TestData
            {
                DistrictImport = query.Select(x => x.Districts).ToList(),
                AddressImport = query.Select(x => x.Addresses.Select(z => z.Addresses)).ToList(),
                LocationImports = query.Select(x => x.Addresses.Select(z => z.Location).ToList())
            });

            foreach (var data in testData.Select(x => x.DistrictImport))
            {
                foreach (var item in data)
                {
                    var x = AddDistrict(item);
                }
            }

            foreach (var address in testData.Select(x=>x.AddressImport))
            {
                foreach (var location in address)
                {
                    foreach (var item in location)
                    {
                        var x = 
                    }
                }
            }
        }

        private int AddDistrict(string district)
        {
            var isCached = _districtCache.TryGetValue(district, out var id);
            if (isCached)
                return id;

            var result = _districtService.GetItem(x => x.Name == district);

            if (result != null) 
                return result.Id;

            var districtId = _districtService.Add(new DistrictEntity { Name = district });
            _districtCache.Add(district,districtId);

            return _districtService.Save();

        }
        private int 
    }

    public class TestData
    {
        public IEnumerable<string> DistrictImport { get; set; }
        public IEnumerable<IEnumerable<string>> AddressImport { get; set; }
        public IEnumerable<IEnumerable<List<LocationImport>>> LocationImports { get; set; }
    }
}