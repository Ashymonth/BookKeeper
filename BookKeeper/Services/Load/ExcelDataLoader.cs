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
        private readonly IDictionary<string,int> _districtCache = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        private readonly IImport _import;
        private readonly IDistrictService _districtService;

        public ExcelDataLoader(IImport import, IDistrictService districtService)
        {
            _import = import;
            _districtService = districtService;
        }

        public void LoadData(string file)
        {
            var importData = _import.ImportDataRow(file);


            foreach (var data in importData)
            {
               
            }
        }

        private int Som(IEnumerable<DistrictImport> imports)
        {
            var query = imports.Select(x => x.Name).Distinct().ToList();

            foreach (var item in query)
            {
                _districtService.GetItem(x => x.Name == item);
            }

            return 1;
        }

        private int AddDistrict(DistrictImport import)
        {
            var cache = _districtCache.TryGetValue(import.Name, out var id);
            if (cache)
                return id;

            var district =
                _districtService.GetItem(x => x.Name.Equals(import.Name, StringComparison.OrdinalIgnoreCase));

            if (district != null)
            {
                _districtCache.Add(district.Name,district.Id);
                return district.Id;
            }

            var districtId = _districtService.Add(new DistrictEntity
            {
                Name = import.Name,
                DistrictType = GetDistrictType(import.Code)
            });

            _districtCache.Add(import.Name,districtId);

            return districtId;
        }

        private static DistrictType GetDistrictType(int serviceCode)
        {
            return serviceCode.ToString().StartsWith("6") ? DistrictType.Private : DistrictType.Municipal;
        }
    }
}