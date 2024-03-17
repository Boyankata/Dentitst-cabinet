using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dentist_cabinet.Models;

namespace Dentist_cabinet.Data
{
    public class Dentist_cabinetContext : DbContext
    {
        public Dentist_cabinetContext (DbContextOptions<Dentist_cabinetContext> options)
            : base(options)
        {
        }

        public DbSet<Dentist_cabinet.Models.Client> Client { get; set; } = default!;

        public DbSet<Dentist_cabinet.Models.Doctor> Doctor { get; set; } = default!;

        public DbSet<Dentist_cabinet.Models.Times> Times { get; set; } = default!;
    }
}
