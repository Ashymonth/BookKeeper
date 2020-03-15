namespace BookKeeper.Data.Data.Entities.Address
{
    public enum DistrictType
    {
        Municipal,
        Private
    }

    public class DistrictEntity : BaseEntity
    {
        public string Name { get; set; }

    }
}
