namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ProviderModels : DbContext
    {
        public ProviderModels()
            : base("name=ProviderModels")
        {
        }

        public virtual DbSet<Provider> Providers { get; set; }

    }

    public class Provider
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string HomepageURL { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Offering> Offerings { get; set; }
    }
}