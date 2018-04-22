namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class PricingModels : DbContext
    {
      
        public PricingModels()
            : base("name=PricingModels")
        {
        }

        public virtual DbSet<Pricing> Pricings{ get; set; }
    }

    public class Pricing
    {
        public int PricingId { get; set; }
        public double Price { get; set; }
        public string URL { get; set; }


        public virtual ICollection<Offering> Offerings { get; set; }

        public int MobilPhoneId { get; set; }
        public virtual MobilePhone MobilPhone { get; set; }

        public int MobilfunkId { get; set; }
        public virtual Mobilfunk Mobilfunk{ get; set; }

    }
}