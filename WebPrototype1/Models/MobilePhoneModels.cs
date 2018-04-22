namespace WebPrototype1.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MobilePhoneModels : DbContext
    {
       
        public MobilePhoneModels()
            : base("name=MobilePhoneModels")
        {
        }


        public virtual DbSet<MobilePhone> MobilePhones { get; set; }
    }

    public class MobilePhone
    {
        public int MobilePhoneId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        

    }
    
}