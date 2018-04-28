namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class OfferingModels : DbContext
    {
        public OfferingModels()
            : base("name=OfferingModels")
        {
        }

        public virtual DbSet<Offering> Offerings { get; set; }
    }

    public class Offering
    {
        [Key]
        public int OfferingId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        public virtual Provider Provider { get; set; }

        [Required]
        public virtual ICollection<Pricing> Pricings { get; set; }


    }
}