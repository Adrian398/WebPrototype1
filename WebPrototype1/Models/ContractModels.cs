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
        public double Price { get; set; }
        public string Name { get; set; }
        public int ProviderId { get; set; }
        public virtual Provider Provider { get; set; }
        public int MobilfunkId { get; set; }
        public double DataVolume { get; set; }
        public int FreeMinutes { get; set; }
        public int FreeSMS { get; set; }
        public bool EURoaming { get; set; }
        public string NetworkSpeed { get; set; }
        public string NetworkThrottling{ get; set; }
        public string Network { get; set; }
        public string RunningTime { get; set; }
        public bool YoungPeople { get; set; }
        public bool SustainYourNumber { get; set; }
        public int MobilePhoneId { get; set; }
        public virtual MobilePhone MobilePhone{ get; set; }
    }
}