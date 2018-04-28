namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class PricingModels : DbContext
    {

        public PricingModels()
            : base("name=PricingModels")
        {
        }

        public virtual DbSet<Pricing> Pricings { get; set; }
    }

    public class Pricing
    {
        [Key]
        public int PricingId { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public virtual ICollection<Offering> Offerings { get; set; }

        [Required]
        public int MobilPhoneId { get; set; }
        [Required]
        public virtual MobilePhone MobilPhone { get; set; }

        [Required]
        public int MobilfunkId { get; set; }
        [Required]
        public virtual Mobilfunk Mobilfunk { get; set; }

    }
}