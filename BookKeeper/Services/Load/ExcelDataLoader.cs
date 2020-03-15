using System;
using System.Collections.Generic;
using System.Linq;
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
            var tes =
                from result in import
                group result by result.District
                into district
                group district by district.Key.Name
                (from address in district 
                    group address by address.Address into new )

            var districtsId = AddDistrict(query.Select(x => x.Districts));

        }

        private IEnumerable<int> AddDistrict(IEnumerable<string> districtList)
        {
            var districtsId = new List<int>();
            foreach (var district in districtList)
            {
                var result = _districtService.GetItem(x => x.Name == district);
                districtsId.Add(result?.Id ?? _districtService.Add(new DistrictEntity { Name = district }));
            }

            return districtsId;
        }
    }

    public class TestData
    {
        public DistrictImport DistrictImport { get; set; }
        public AddressImport AddressImport { get; set; }
        public List<LocationImport> LocationImports { get; set; }
    }
}