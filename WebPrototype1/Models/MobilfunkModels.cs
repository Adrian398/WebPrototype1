namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class MobilfunkModels : DbContext
    {
        public MobilfunkModels()
            : base("name=MobilfunkModels")
        {
        }

        public virtual DbSet<Mobilfunk> Mobilfunks { get; set; }
    }

    public class Mobilfunk
    {
        [Key]
        public int MobilfunkId { get; set; }
        public double DataVolume { get; set; }
        public int FreeMinutes { get; set; }
        public int FreeSMS { get; set; }
        public bool EURoaming { get; set; }
        public string NetworkSpeed { get; set; }
        public string NetworkThrottling { get; set; }

        [Required]
        public string Network { get; set; }
        public string RunningTime { get; set; }
        public bool SustainYourNumber { get; set; }

        [Required]
        public int ContractId { get; set; }

        [Required]
        public Contract Contract { get; set; }

        [Required]
        public virtual ICollection<Pricing> Pricings { get; set; }

    }
}