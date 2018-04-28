namespace WebPrototype1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class RatingModels : DbContext
    {
        public RatingModels()
            : base("name=RatingModels")
        {
        }

        public virtual DbSet<Rating> Ratings { get; set; }
    }


    public enum RatingEnum
    {
        NONE, ONE, TWO, THREE, FOUR, FIVE
    }
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        public RatingEnum Valuation { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        [Required]
        public int ContractId { get; set; }

        [Required]
        public virtual Contract Contract { get; set; }
    }
}