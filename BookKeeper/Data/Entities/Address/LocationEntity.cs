using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace BookKeeper.Data.Data.Entities.Address
{
    public class LocationEntity : BaseEntity
    {
        public int StreetId { get; set; }

        public int AccountId { get; set; }

        [ForeignKey(nameof(StreetId))]
        public StreetEntity Street { get; set; }

        [ForeignKey(nameof(AccountId))] 
        public AccountEntity Account { get; set; }

        public string HouseNumber { get; set; }

        public string BuildingCorpus { get; set; }

        public string ApartmentNumber { get; set; }

    }
}
