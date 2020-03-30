using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeper.Data.Data.Entities.Address
{
    public enum DistrictType
    {
        Municipal,
        Private
    }

    [Table("Districts")]
    public class DistrictEntity : BaseEntity
    {
        public int Code { get; set; }

        public string Name { get; set; }

    }
}
