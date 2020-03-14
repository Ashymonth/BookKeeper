using System;

namespace BookKeeper.Data.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastSaveDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
