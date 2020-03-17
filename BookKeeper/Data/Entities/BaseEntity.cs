using System;
using System.ComponentModel.DataAnnotations;

namespace BookKeeper.Data.Data.Entities
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDate = LastSaveDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastSaveDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
