namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int ContractId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }


        [Required]
        public int ProviderId { get; set; }

        [Required]
        public virtual Provider Provider { get; set; }
    }
}