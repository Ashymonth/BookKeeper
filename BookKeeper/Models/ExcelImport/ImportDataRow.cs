namespace BookKeeper.Data.Models.ExcelImport
{
    public class ImportDataRow
    {
        public AddressImport Address { get; set; }
        public DistrictImport District { get; set; }
        public AccountImport Account { get; set; }
        public LocationImport LocationImport { get; set; }
    }
}