using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppECommerce.Models;

namespace WebAppECommerce.Data
{
    public class AppliDbContext: DbContext
    {
        public AppliDbContext(DbContextOptions<AppliDbContext> options): base(options)
        {
        }
          public DbSet<User> users { get; set; }
        public DbSet<Produit> Produits { get; set; }

    }
}
