namespace WebPrototype1.Models
{
    using System;
    using System.Collections.Generic;
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
        public int MobilfunkId { get; set; }
        public double DataVolume { get; set; }
        public int FreeMinutes { get; set; }
        public int FreeSMS { get; set; }
        public bool EURoaming { get; set; }
        public string NetworkSpeed { get; set; }
        public string NetworkThrottling { get; set; }
        public string Network { get; set; }
        public string RunningTime { get; set; }
        public bool SustainYourNumber { get; set; }

        public int ContractId { get; set; }
        public Contract Contract { get; set; }

        public virtual ICollection<Pricing> Pricings { get; set; }


        // RATING


    }
}