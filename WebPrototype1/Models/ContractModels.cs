namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ContractModels : DbContext
    {
        public ContractModels()
            : base("name=ContractModels")
        {
        }
        public virtual DbSet<Contract> Contracts { get; set; }
    }

    public class Contract
    {   
        public int ContractId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        

        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
    }
}


}