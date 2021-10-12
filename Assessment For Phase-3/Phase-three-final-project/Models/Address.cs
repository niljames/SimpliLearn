using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phase_three_final_project.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Addrss { get; set; }
        [Required]
        public int Zipcode { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public long Phone { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
