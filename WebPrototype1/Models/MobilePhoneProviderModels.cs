namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class MobilePhoneProviderModels : DbContext
    {
        public MobilePhoneProviderModels()
            : base("name=MobilePhoneProviderModels")
        {
        }

        public virtual DbSet<MobilePhoneProvider> MobilePhoneProviders { get; set; }
    }

    public class MobilePhoneProvider
    {
        [Key]
        public int MobilePhoneProviderId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public virtual ICollection<MobilePhone> MobilePhones { get; set; }
    }
}