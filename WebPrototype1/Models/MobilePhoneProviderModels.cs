namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
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
        public int MobilePhoneProviderId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public virtual ICollection<MobilePhone> MobilePhones { get; set; }
    }
}