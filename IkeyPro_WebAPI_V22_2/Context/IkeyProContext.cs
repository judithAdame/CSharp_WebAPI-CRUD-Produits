using IkeyPro_WebAPI_V22_2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IkeyPro_WebAPI_V22_2.Context
{
    public class IkeyProContext : DbContext
    {
        public IkeyProContext(DbContextOptions<IkeyProContext> options) 
            : base(options) { }

        public DbSet<Produit> Produits { get; set; }
    }
}
