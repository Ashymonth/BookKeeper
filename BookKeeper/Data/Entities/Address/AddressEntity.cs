namespace BookKeeper.Data.Data.Entities.Address
{
    public class AddressEntity : BaseEntity
    {
        public int DistrictId { get; set; }
        public virtual DistrictEntity District { get; set; }

        public int LocationId { get; set; }
        public virtual LocationEntity Location { get; set; }
    }
}
