namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int ProviderId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string HomepageURL { get; set; }

        [Required]
        public virtual ICollection<Contract> Contracts { get; set; }

        [Required]
        public virtual ICollection<Offering> Offerings { get; set; }
    }
}