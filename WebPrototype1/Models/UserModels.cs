namespace WebPrototype1.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserModels : DbContext
    {
        public UserModels()
            : base("name=UserModels")
        {
        }
        
         public virtual DbSet<User> Users{ get; set; }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Prename { get; set; }
        public string Surname { get; set; }
        public string Zipcode { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public int AppicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
    }