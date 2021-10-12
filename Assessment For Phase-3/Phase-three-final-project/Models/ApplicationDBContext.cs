using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phase_three_final_project.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Description> Description { get; set; }

        public DbSet<Address>Address { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Configuring Connection String.
            optionsBuilder.UseSqlServer("Server=H5CG125CX26;Database=PhaseThree;Integrated Security=true");
        }

    }
}
