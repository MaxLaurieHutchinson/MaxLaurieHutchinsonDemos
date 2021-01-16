using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MLHDemosAPIs.Models;

namespace MLHDemosAPIs.Data
{
    public class MLHDemosAPIsContext : DbContext
    {
        public MLHDemosAPIsContext (DbContextOptions<MLHDemosAPIsContext> options)
            : base(options)
        {
        }

        public DbSet<MLHDemosAPIs.Models.Product> Product { get; set; }
        public DbSet<MLHDemosAPIs.Models.People> People { get; set; }
    }
}
