using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wsei.Lab1.Controllers.Entities;

namespace Wsei.Lab1.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public AppDbContext(DbContextOptions options)
        : base(options)
        {
        }
    }
}
