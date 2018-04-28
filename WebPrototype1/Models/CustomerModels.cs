namespace WebPrototype1.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class CustomerModels : DbContext
    {
        public CustomerModels()
            : base("name=UserModels")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
    }

    public enum Salutation
    {
        NONE, MALE, FEMALE
    }

    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public Salutation Salutation { get; set; }

        [Required]
        public string Prename { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Zipcode { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string HouseNumber { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        [Required]
        public int AppicationUserId { get; set; }

        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}