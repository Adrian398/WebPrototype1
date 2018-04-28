namespace WebPrototype1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int MobilePhoneId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public int MobilePhoneProviderId { get; set; }

        [Required]
        public MobilePhoneProvider MobilePhoneProvider { get; set; }


    }

}