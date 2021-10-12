using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phase_three_final_project.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }
        [Required]

        [DataType(DataType.DateTime)]
        public DateTime UserAddedDate { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
