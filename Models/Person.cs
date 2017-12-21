using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServerWithAspNetIdentity.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public string FullName {
            get { return FirstName + " " + Surname;  }
        }

        public DateTime? HireDate { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}