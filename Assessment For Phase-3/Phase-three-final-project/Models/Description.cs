using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phase_three_final_project.Models
{
    public class Description
    {
        public int DescriptionId { get; set; }

        [Required]
        public string OS { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public string Memory { get; set; }

        [Required]
        public string HardDrive { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
